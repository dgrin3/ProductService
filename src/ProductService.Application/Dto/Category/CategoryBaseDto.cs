using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Category
{
    /// <summary>
    /// Response-Daten der Kategorie ohne Id
    /// </summary>
    public class CategoryBaseDto
    {
        /// <summary>
        /// Kategoriename
        /// </summary>
        public string Name { get; set; }

    }
}
