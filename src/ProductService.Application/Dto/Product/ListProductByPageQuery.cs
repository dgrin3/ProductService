using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    /// <summary>
    /// Abfrage für Produktliste
    /// </summary>
    public class ListProductByPageQuery
    {
        /// <summary>
        /// Seitenummer
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Seitegröße
        /// </summary>
        public int PageSize { get; set; }
    }
}
