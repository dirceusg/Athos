using Athos.Entity.entities;
using FluentValidation;

namespace Athos.Domain.Validation
{
    public class AdministradoraValidation : AbstractValidator<Administradora>
    {
        public AdministradoraValidation()
        {
            RuleFor(x=>x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
