using FluentValidation;
using InventarioVeagroApi.Messages.Request;

namespace InventarioVeagroApi.Validators
{
    public class GeneralReqDTOValidator<T> : AbstractValidator<GenericReqDTO<T>>
    {
        public GeneralReqDTOValidator() {

            RuleFor(x => x.payload)
           .NotNull().WithMessage("El campo payload es obligatorio")
           .SetValidator(new DynamicPayloadValidator<T>()); // Aplica validación de T si existe

            RuleFor(x => x.origin)
                .NotEmpty().WithMessage("El campo origin es obligatorio");

            RuleFor(x => x.usrRequest)
                .NotEmpty().WithMessage("El campo usrRequest es obligatorio");
        }
    }

    // Validador dinámico que solo se ejecuta si hay un validador registrado para T
    public class DynamicPayloadValidator<T> : AbstractValidator<T>
    {
        public DynamicPayloadValidator()
        {
            Include(ValidatorHelper.GetValidatorForType<T>());
        }
    }

    // Helper para obtener el validador de T dinámicamente
    public static class ValidatorHelper
    {
        public static IValidator<T> GetValidatorForType<T>()
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));
            var validator = Activator.CreateInstance(validatorType) as IValidator<T>;
            return validator ?? new InlineValidator<T>();
        }
    }
}


