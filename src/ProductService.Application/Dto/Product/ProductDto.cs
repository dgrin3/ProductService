using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    /// <summary>
    /// Response-Daten der Product
    /// </summary>
    public class ProductDto : ProductBaseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
