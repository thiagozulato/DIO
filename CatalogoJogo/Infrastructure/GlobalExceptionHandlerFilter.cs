
using System.Net;
using CatalogoJogo.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Infrastructure.Filters
{
    public class GlobalExceptionHandlerFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlerFilter> logger;

        public GlobalExceptionHandlerFilter(ILogger<GlobalExceptionHandlerFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception.GetType() == typeof(DomainCoreException))
            {
                var problemDetails = new ProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Ocorreu um problema na requisição. Consulte os logs para detalhes.",
                    Detail = context.Exception.Message

                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.Result = new ObjectResult(new ProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "Ocorreu um problema na requisição. Consulte os logs para detalhes."
                });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }
}