using FluentValidation;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Security.Messages;

namespace InventarioVeagroApi.Validators
{
    public class AuthReqDTOValidator : AbstractValidator<AuthReqDTO>
    {
        public AuthReqDTOValidator() {


            RuleFor(x => x.username)
              .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(x => x.password)
              .NotEmpty().WithMessage("La contrasena es obligatoria");
        }
    }
}
