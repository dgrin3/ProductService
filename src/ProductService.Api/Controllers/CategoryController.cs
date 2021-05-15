using Microsoft.AspNetCore.Authorization;
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
    /// Controller für eine Kategorie.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("`Kategorie`")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        /// <summary>
        /// Erstellen neuer Kategorie
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Id der neuen Kategorie</returns>
        [HttpPost]
        [OpenApiOperation(
            operationId: nameof(AddAsync),
            summary: "Erstellen der Kategorie",
            description: "Erstellen der Kategorie")]
        public async Task<IActionResult> AddAsync([FromBody] AddCategoryCommand category, CancellationToken cancellationToken)
            => Ok(await _categoryApplication.AddAsync(category, cancellationToken));

        /// <summary>
        /// Veränderung der Kategorie
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>.</returns>
        [HttpPut]
        [OpenApiOperation(
            operationId: nameof(ChangeAsync),
            summary: "Veränderung der Kategorie",
            description: "Veränderung der Kategorie")]
        public async Task<IActionResult> ChangeAsync([FromBody] ChangeCategoryCommand category, CancellationToken cancellationToken)
        {
            await _categoryApplication.ChangeAsync(category, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Löschen der Kategorie
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>.</returns>
        [HttpDelete("{CategoryId:int}")]
        [OpenApiOperation(
            operationId: nameof(DeleteAsync),
            summary: "Löschen der Kategorie",
            description: "Löschen der Kategorie")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteCategoryCommand category, CancellationToken cancellationToken)
        {
            await _categoryApplication.DeleteAsync(category, cancellationToken);

            return Ok();
        }
    }
}
