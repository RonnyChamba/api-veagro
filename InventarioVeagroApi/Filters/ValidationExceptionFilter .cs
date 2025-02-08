using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventarioVeagroApi.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                var errorMessage = new StringBuilder("Errores de validación encontrados:");

              

                context.Result = new BadRequestObjectResult(errorMessage.ToString());
                context.ExceptionHandled = true;
            }
        }
    }
}
