using Microsoft.EntityFrameworkCore;
using ProductService.Application.Dto.Category;
using ProductService.Application.Exceptions;
using ProductService.Application.Interface;
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
    /// Repository der Kategorien - EF-Implementierung
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _context;

        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<int> AddAsync(CategoryBaseDto category, CancellationToken cancellationToken)
        {
            var categoryEntity = new CategoryEntity
            {
                Name = category.Name,
            };
            await _context.Categories.AddAsync(categoryEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return categoryEntity.Id;
        }

        ///<inheritdoc/>
        public async Task ChangeAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var categoryEntity = await GetByIdAsync(category.Id, cancellationToken);

            categoryEntity.Name = category.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(int categoryId, CancellationToken cancellationToken)
        {
            var categoryEntity = await GetByIdAsync(categoryId, cancellationToken);
            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<CategoryDto>> ListByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Select(p => p.MapToCategoryDto())
                .ToListAsync(cancellationToken);
        }

        private async Task<CategoryEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Categories
                    .Where(p => p.Id == id)
                    .SingleAsync(cancellationToken);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException("Category", $"id = {id}", ex);
            }
        }

    }
}
