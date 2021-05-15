using ProductService.Application.Dto.Product;
using ProductService.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Interface
{
    /// <summary>
    /// Repository-Methoden der Produkte
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Auflisten der Produkte nach Seite
        /// </summary>
        /// <returns>Liste der Produkte</returns>
        Task<IEnumerable<ProductDto>> ListByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        /// <summary>
        /// Erstellen des Produkts
        /// </summary>
        /// <returns>Produkt Id</returns>
        Task<int> AddAsync(ProductBaseDto product, CancellationToken cancellationToken);

        /// <summary>
        /// Änderung des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task ChangeAsync(ProductDto product, CancellationToken cancellationToken);

        /// <summary>
        /// Löschen des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task DeleteAsync(int productId, CancellationToken cancellationToken);
    }
}
