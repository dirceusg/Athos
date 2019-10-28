using Athos.Entity.entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Domain.Validation
{
    public class ComunicadoValidation : AbstractValidator<Comunicado>
    {
        public ComunicadoValidation()
        {
            RuleFor(x => x.Mensagem)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 3000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
