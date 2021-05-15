using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductService.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Api.Filters
{
    /// <summary>
    /// API action filter
    /// </summary>
    internal class ApiActionFilter : IAsyncActionFilter
    {
        /// <inheritdoc/>
        public async Task OnActionExecutionAsync(ActionExecutingContext actionExecutingContext, ActionExecutionDelegate next)
        {
            if (ValidateModelState(actionExecutingContext))
            {
                await next()
                  .ContinueWith(
                      async taskNext =>
                      {
                          if (taskNext.Status != TaskStatus.Canceled)
                          {
                              await CheckResultAsync(actionExecutingContext, await taskNext);
                          }
                      });
            }
        }

        /// <summary>
        /// Check request model.
        /// </summary>
        /// <param name="actionExecutingContext"><see cref="ActionExecutingContext"/></param>
        /// <returns><see cref="true"/></returns>
        private bool ValidateModelState(ActionExecutingContext actionExecutingContext)
        {
            if (!actionExecutingContext.ModelState.IsValid)
            {
                actionExecutingContext.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Check response result.
        /// </summary>
        /// <param name="actionExecutingContext"><see cref="ActionExecutingContext"/></param>
        /// <param name="actionExecutedContext"><see cref="ActionExecutedContext"/></param>
        /// <returns><see cref="Task"/></returns>
        private Task CheckResultAsync(ActionExecutingContext actionExecutingContext, ActionExecutedContext actionExecutedContext)
        {
            switch (actionExecutedContext.Exception)
            {
                case NotFoundException tex:
                    actionExecutingContext.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    ExceptionApiProblemDetails(actionExecutingContext, actionExecutedContext, tex);

                    return Task.FromCanceled(new CancellationToken(true));

                case Exception ex:
                    actionExecutingContext.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    ExceptionApiProblemDetails(actionExecutingContext, actionExecutedContext, ex);

                    return Task.FromCanceled(new CancellationToken(true));
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Put exception data into problem detail 
        /// </summary>
        /// <param name="actionExecutingContext"></param>
        /// <param name="actionExecutedContext"></param>
        /// <param name="ex"></param>
        private void ExceptionApiProblemDetails(ActionExecutingContext actionExecutingContext, ActionExecutedContext actionExecutedContext, Exception ex)
        {
            var apiProblemDetails = new ProblemDetails();
            apiProblemDetails.Detail = ex.Message;
            apiProblemDetails.Extensions.Add("source", ex.Source);
            if (ex.InnerException?.Message != default)
            {
                apiProblemDetails.Extensions.Add("innerDetail", ex.InnerException.Message);
            }

            var objectResult = new ObjectResult(apiProblemDetails);

            objectResult.StatusCode = actionExecutingContext.HttpContext.Response.StatusCode;
            actionExecutedContext.Result = objectResult;
            actionExecutedContext.ExceptionHandled = true;
        }
    }
}
