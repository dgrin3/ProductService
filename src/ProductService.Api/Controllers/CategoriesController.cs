using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using ProductService.Application.Dto.Category;
using ProductService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Api.Controllers
{
    /// <summary>
    /// Controller für Kategorieliste.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("`Kategorien`")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoriesController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        /// <summary>
        /// Kategorieliste nach Seite
        /// </summary>
        /// <param name="query">Objekte mit PageNumber (bei 0 startend) und PageSize</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Kategorieliste</returns>
        [HttpGet("{PageNumber:int}/{PageSize:int}")]
        [OpenApiOperation(
            operationId: nameof(ListByPageAsync),
            summary: "Kategorieliste nach Seite",
            description: "Kategorieliste nach Seite")]
        [ResponseType(typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> ListByPageAsync([FromRoute] ListCategoriesByPageQuery query, CancellationToken cancellationToken)
            => Ok(await _categoryApplication.ListByPageAsync(query, cancellationToken));

    }
}
