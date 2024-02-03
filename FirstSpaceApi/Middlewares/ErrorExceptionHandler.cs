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
                // Caught an error 
                var errorResponse = new ErrorResponseVM(System.Net.HttpStatusCode.InternalServerError, ex.Message);

                // Serilize errorResponse
                var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);

                // Set the response status code and content type
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                // Write the JSON response to the output
                await context.Response.WriteAsync(jsonErrorResponse);
            }
        
        }

    }
}
