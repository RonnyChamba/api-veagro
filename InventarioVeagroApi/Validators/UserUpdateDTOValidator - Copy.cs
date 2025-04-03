using FluentValidation;
using InventarioVeagroApi.Messages.Request;

namespace InventarioVeagroApi.Validators
{
    public class UserUpdateReqDTOValidator : AbstractValidator<UserUpdateReqDTO>
    {
        public UserUpdateReqDTOValidator() { 
            
 
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("El name es obligatorio")
              .MaximumLength(100).WithMessage("La longitud permitidad es 100 numeros");
        }
    }
}
