﻿using FluentValidation;
using InventarioVeagroApi.Messages.Request;

namespace InventarioVeagroApi.Validators
{
    public class UserReqDTOValidator : AbstractValidator<UserReqDTO>
    {
        public UserReqDTOValidator() { 
            
            RuleFor(x => x.Dni)
                .NotEmpty().WithMessage("El dni es obligatorio")
                .MinimumLength(10).WithMessage("La longitud minima permitida del dni es 10 numeros")
                .MaximumLength(13).WithMessage("La longitud maxima permitida del dni es 13 numeros");

            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("El name es obligatorio")
              .MaximumLength(100).WithMessage("La longitud permitidad es 100 numeros");

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("El password es obligatorio")
              .MaximumLength(50).WithMessage("La longitud permitidad es 50 numeros");


            RuleFor(x => x.RolName)
              .NotEmpty().WithMessage("El rol es obligatorio")
              .MaximumLength(50).WithMessage("La longitud permitidad es 50 numeros");
        }
    }
}
