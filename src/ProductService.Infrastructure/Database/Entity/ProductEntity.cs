using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Database.Entity
{
    /// <summary>
    /// Produkt-Entität der Datenbank
    /// </summary>
    public class ProductEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Kategorie als verbundene Entität
        /// </summary>
        public CategoryEntity Category { get; set; }
    }
}
