using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    /// <summary>
    /// Response-Daten der Product ohne Id
    /// </summary>
    public class ProductBaseDto
    {
        /// <summary>
        /// Produktname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preis
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Beschreibung
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Kategorie Id
        /// </summary>
        public int CategoryId { get; set; }
    }
}
