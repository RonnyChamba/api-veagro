using FluentValidation;
using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;

namespace InventarioVeagroApi.Services.impl
{
    public class ValidatoServiceImpl : IValidatorService
    {
        private readonly IValidator<CustomerReqDTO> _validator;

        public ValidatoServiceImpl(IValidator<CustomerReqDTO> validator) 
        { 
            _validator = validator;
        }

         async Task IValidatorService.ValidatorReqCustomer(CustomerReqDTO customerReq)
        {

            var validationResult = await _validator.ValidateAsync(customerReq);

            if (!validationResult.IsValid)
            {
                var errores = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new GenericException($"El objeto recibido es inválido: {errores}");

            }
        }
    }
}
