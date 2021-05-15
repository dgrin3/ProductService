using ProductService.Application.Dto.Category;
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
    public static class CategoryMappingExtensions
    {
        /// <summary>
        /// Mapping auf CategoryDto
        /// </summary>
        /// <param name="p"></param>
        /// <returns>ProductDto</returns>
        public static CategoryDto MapToCategoryDto(this CategoryEntity p)
            => new()
            {
                Id = p.Id,
                Name = p.Name
            };
    }
}
