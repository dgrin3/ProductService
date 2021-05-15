using ProductService.Application.Dto.Product;
using ProductService.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Mapping
{
    /// <summary>
    /// Erweiterungsmethoden für Produkt
    /// </summary>
    public static class ProductExtensions
    {
        /// <summary>
        /// Mapping auf ProductDto
        /// </summary>
        /// <param name="p"></param>
        /// <returns>ProductDto</returns>
        public static ProductDto MapToDto(this Product p)
            => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryId = p.CategoryId
            };
    }
}
