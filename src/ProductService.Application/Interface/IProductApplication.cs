using ProductService.Application.Dto;
using ProductService.Application.Dto.Product;
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
    public interface IProductApplication
    {
        /// <summary>
        /// Auflisten der Produkte nach Seite
        /// </summary>
        /// <returns>Liste der Produkte</returns>
        Task<IEnumerable<ProductDto>> ListByPageAsync(ListProductByPageQuery query, CancellationToken cancellationToken);

        /// <summary>
        /// Erstellen des Produkts
        /// </summary>
        /// <returns>Liste der Produkte.</returns>
        Task<int> AddAsync(AddProductCommand product, CancellationToken cancellationToken);

        /// <summary>
        /// Änderung des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task ChangeAsync(ChangeProductCommand product, CancellationToken cancellationToken);

        /// <summary>
        /// Löschen des Produkts
        /// </summary>
        /// <returns>.</returns>
        Task DeleteAsync(DeleteProductCommand productId, CancellationToken cancellationToken);
    }
}
