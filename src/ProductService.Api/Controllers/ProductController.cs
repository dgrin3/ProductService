using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interface;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Application.Dto;
using ProductService.Application.Dto.Product;

namespace ProductService.Api.Controllers
{
    /// <summary>
    /// Controller für ein Produkt.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("`Produkt`")]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        /// <summary>
        /// Erstellen des Produkts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Id des neuen Produkts</returns>
        [HttpPost]
        [OpenApiOperation(
            operationId: nameof(AddAsync),
            summary: "Erstellen des Produkts",
            description: "Erstellen des Produkts")]
        public async Task<IActionResult> AddAsync(AddProductCommand product, CancellationToken cancellationToken)
            => Ok(await _productApplication.AddAsync(product, cancellationToken));

        /// <summary>
        /// Veränderung des Produkts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>.</returns>
        [HttpPut]
        [OpenApiOperation(
            operationId: nameof(ChangeAsync),
            summary: "Veränderung des Produkts",
            description: "Veränderung des Produkts")]
        public async Task<IActionResult> ChangeAsync(ChangeProductCommand product, CancellationToken cancellationToken)
        {
            await _productApplication.ChangeAsync(product, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Löschen des Produkts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>.</returns>
        [HttpDelete("{ProductId:int}")]
        [OpenApiOperation(
            operationId: nameof(DeleteAsync),
            summary: "Löschen des Produkts",
            description: "Löschen des Produkts")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteProductCommand product, CancellationToken cancellationToken)
        {
            await _productApplication.DeleteAsync(product, cancellationToken);

            return Ok();
        }
    }
}
