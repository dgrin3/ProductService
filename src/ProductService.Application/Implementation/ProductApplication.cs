using ProductService.Application.Dto.Product;
using ProductService.Application.Interface;
using ProductService.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Implementation
{
    /// <summary>
    /// Implementierung des Produkt-Service
    /// </summary>
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddAsync(AddProductCommand product, CancellationToken cancellationToken)
        {
            return await _productRepository.AddAsync(product, cancellationToken);
        }

        public async Task ChangeAsync(ChangeProductCommand product, CancellationToken cancellationToken)
        {
            await _productRepository.ChangeAsync(product, cancellationToken);
        }

        public async Task DeleteAsync(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(command.ProductId, cancellationToken);
        }


        ///<inheritdoc/>
        public async Task<IEnumerable<ProductDto>> ListByPageAsync(ListProductsByPageQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListByPageAsync(query.PageNumber, query.PageSize, cancellationToken);

            return products.ToList();
        }
    }
}
