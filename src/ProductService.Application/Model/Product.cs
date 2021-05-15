using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Model
{
    /// <summary>
    /// Produktmodell
    /// </summary>
    public class Product
    {
        public Product(int id, string name, decimal price, string description, int categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Produktname
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Preis
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Beschreibung
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Kategorie Id
        /// </summary>
        public int CategoryId { get; private set; }
    }
}
