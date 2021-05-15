using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Database.Entity
{
    /// <summary>
    /// Kategorie-Entität der Datenbank
    /// </summary>
    public class CategoryEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kategoriename
        /// </summary>
        public string Name { get; set; }
    }
}
