using FluentValidation;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Security.Messages;

namespace InventarioVeagroApi.Validators
{
    public class CustomerReqDTOValidator : AbstractValidator<CustomerReqDTO>
    {
        public CustomerReqDTOValidator() {


            RuleFor(x => x.Dni)
              .NotEmpty().WithMessage("El dni es obligatorio");

            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("El nombre es obligatoria");
        }
    }
}
