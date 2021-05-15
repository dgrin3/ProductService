using ProductService.Application.Dto.Product;
using ProductService.Infrastructure.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Database.Mapping
{
    /// <summary>
    /// Erweiterungsmethoden für ProductEntity
    /// </summary>
    public static class ProductMappingExtensions
    {
        /// <summary>
        /// Mapping auf ProductDto
        /// </summary>
        /// <param name="p"></param>
        /// <returns>ProductDto</returns>
        public static ProductDto MapToProduct(this ProductEntity p)
            => new()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryId = p.CategoryId
            };
    }
}
