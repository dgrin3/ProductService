using Microsoft.EntityFrameworkCore;
using ProductService.Application.Dto.Product;
using ProductService.Application.Exceptions;
using ProductService.Application.Interface;
using ProductService.Application.Model;
using ProductService.Infrastructure.Database;
using ProductService.Infrastructure.Database.Entity;
using ProductService.Infrastructure.Database.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repository
{
    /// <summary>
    /// Repository der Produkte - EF-Implementierung
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(ProductContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        ///<inheritdoc/>
        public async Task<int> AddAsync(ProductBaseDto product, CancellationToken cancellationToken)
        {
            if (!await _categoryRepository.IsValidIdAsync(product.CategoryId, cancellationToken))
            {
                throw new NotFoundException("Category", $"id = {product.CategoryId}");
            }
            
            var productEntity = new ProductEntity
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId
            };
            await _context.Products.AddAsync(productEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return productEntity.Id;
        }

        ///<inheritdoc/>
        public async Task ChangeAsync(ProductDto product, CancellationToken cancellationToken)
        {
            if (!await _categoryRepository.IsValidIdAsync(product.CategoryId, cancellationToken))
            {
                throw new NotFoundException("Category", $"id = {product.CategoryId}");
            }

            var productEntity = await GetByIdAsync(product.Id, cancellationToken);

            productEntity.Name = product.Name;
            productEntity.Price = product.Price;
            productEntity.Description = product.Description;
            productEntity.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(int productId, CancellationToken cancellationToken)
        {
            var productEntity = await GetByIdAsync(productId, cancellationToken);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<ProductQueryDto>> ListByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking()
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Select(p => p.MapToProductQueryDto())
                .ToListAsync(cancellationToken);
        }

        private async Task<ProductEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products
                    .Where(p => p.Id == id)
                    .SingleAsync(cancellationToken);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException("Product", $"id = {id}", ex);
            }
        }
    }
}
