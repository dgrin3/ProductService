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
    /// Repository-Methoden der Kategorien
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Auflisten der Produkte nach Seite
        /// </summary>
        /// <returns>Liste der Produkte</returns>
        Task<IEnumerable<CategoryDto>> ListByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        /// <summary>
        /// Erstellen des Produkts
        /// </summary>
        /// <returns>Produkt Id</returns>
        Task<int> AddAsync(CategoryBaseDto category, CancellationToken cancellationToken);

        /// <summary>
        /// Änderung des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task ChangeAsync(CategoryDto category, CancellationToken cancellationToken);

        /// <summary>
        /// Löschen des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task DeleteAsync(int categoryId, CancellationToken cancellationToken);

        /// <summary>
        /// Überprüfen, ob Id gültig ist 
        /// </summary>
        /// <returns>.</returns>
        Task<bool> IsValidIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}
