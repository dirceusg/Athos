using Athos.Entity.entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Domain.Validation
{
    public class CondominioValidation : AbstractValidator<Condominio>
    {
        public CondominioValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.AdministradoraId)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
