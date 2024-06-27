using CRUDCsharp.Dtos;
using FluentValidation;

namespace CRUDCsharp.Validators
{
    public class UserInsertValidator : AbstractValidator<UserInsertDto>
    {
        public UserInsertValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe medir de 2 a 20 caracteres");
            RuleFor(x => x.email).NotEmpty().WithMessage("La es edad obligatorio");
            RuleFor(x => x.age).NotEmpty().WithMessage("El email es obligatorio");
            RuleFor(x => x.country).NotEmpty().WithMessage("El pais es obligatorio");
            RuleFor(x => x.phone).NotEmpty().WithMessage("El telefono es obligatorio");
            RuleFor(x => x.city).NotEmpty().WithMessage("La ciudad es obligatorio");
        }
    }
}
