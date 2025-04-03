using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Security.Service;
using InventarioVeagroApi.Util;
using System.Text;

namespace InventarioVeagroApi.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
         
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("LLegando al middleweare");
                // Pasar al siguiente middleware en la cadena
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error capturado en el middlweare {}", ex);
                // Aquí se maneja cualquier excepción no controlada
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Aquí puedes personalizar cómo mostrar el error
            context.Response.ContentType = "application/json";
           

            //// Personaliza el mensaje de error dependiendo del tipo de excepción
            //var errorMessage = new StringBuilder();
            //errorMessage.AppendLine($"Error: {exception.Message}");

            //// Si deseas incluir el stack trace, puedes hacerlo, pero recuerda no enviarlo en producción
            //errorMessage.AppendLine($"StackTrace: {exception.StackTrace}");
            var response = new GenericRespDTO<string>();
            response.message = exception.Message;
            response.status = ConstantVeagro.STATUS_ERROR;
            

            if (exception is GenericException generic)
            {
                response.code = generic.Code;
                context.Response.StatusCode = generic.Code;
            }
            else {
                response.code = context.Response.StatusCode;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            
           return context.Response.WriteAsJsonAsync(response);
        }
    }
}
