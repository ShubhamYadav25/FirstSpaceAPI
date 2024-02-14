using FirstSpaceApi.Shared.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static FirstSpaceApi.Shared.ViewModels.ViewModel;

namespace FirstSpaceApi.Middlewares
{
    public class ErrorExceptionHandler
    {
        // It has reference of next component to be executed in config pipline
        private readonly RequestDelegate _next;

        public ErrorExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            try
            {
                // Execute the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        
        }

        async void HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsync(new ErrorResponseVM()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            }
            .ToString());
        }

    }
}
