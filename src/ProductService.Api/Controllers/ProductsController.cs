using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using ProductService.Application.Dto;
using ProductService.Application.Dto.Product;
using ProductService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Api.Controllers
{
    /// <summary>
    /// Controller für Produktliste.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("`Produkte`")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductsController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        /// <summary>
        /// Produktliste nach Seite
        /// </summary>
        /// <param name="query">Objekte mit PageNumber (bei 0 startend) und PageSize</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Produktliste</returns>
        [HttpGet("{PageNumber:int}/{PageSize:int}")]
        [OpenApiOperation(
            operationId: nameof(ListByPageAsync),
            summary: "Produktliste nach Seite",
            description: "Produktliste nach Seite")]
        public async Task<IActionResult> ListByPageAsync([FromRoute] ListProductsByPageQuery query, CancellationToken cancellationToken)
            => Ok(await _productApplication.ListByPageAsync(query, cancellationToken));

    }
}
