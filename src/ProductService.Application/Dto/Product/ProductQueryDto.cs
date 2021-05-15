using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    public class ProductQueryDto : ProductDto
    {
        /// <summary>
        /// Kategoriename
        /// </summary>
        public string CategoryName { get; set; }
    }
}
