using ProductService.Application.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Interface
{
    /// <summary>
    /// Produkt-Methoden der Applikation-Schicht
    /// </summary>
    public interface ICategoryApplication
    {
        /// <summary>
        /// Auflisten der Produkte nach Seite
        /// </summary>
        /// <returns>Liste der Produkte</returns>
        Task<IEnumerable<CategoryDto>> ListByPageAsync(ListCategoriesByPageQuery query, CancellationToken cancellationToken);

        /// <summary>
        /// Erstellen des Produkts
        /// </summary>
        /// <returns>Liste der Produkte.</returns>
        Task<int> AddAsync(AddCategoryCommand category, CancellationToken cancellationToken);

        /// <summary>
        /// Änderung des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task ChangeAsync(ChangeCategoryCommand category, CancellationToken cancellationToken);

        /// <summary>
        /// Löschen des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task DeleteAsync(DeleteCategoryCommand categoryId, CancellationToken cancellationToken);
    }
}
