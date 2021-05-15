using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Category
{
    /// <summary>
    /// Befehl für Kategorielöschen
    /// </summary>
    public class DeleteCategoryCommand
    {
        /// <summary>
        /// Kategorie Id
        /// </summary>
        public int CategoryId { get; set; }
    }
}
