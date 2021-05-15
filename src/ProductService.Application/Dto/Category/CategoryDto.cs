using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Category
{
    /// <summary>
    /// Response-Daten der Kategorie
    /// </summary>
    public class CategoryDto : CategoryBaseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
