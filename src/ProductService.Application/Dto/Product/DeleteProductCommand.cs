using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    /// <summary>
    /// Befehl für Produktlöschen
    /// </summary>
    public class DeleteProductCommand
    {
        /// <summary>
        /// Produkt Id
        /// </summary>
        public int ProductId { get; set; }
    }
}
