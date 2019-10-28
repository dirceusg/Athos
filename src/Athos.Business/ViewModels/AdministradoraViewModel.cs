using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Athos.Business.ViewModels
{
    public class AdministradoraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        public IEnumerable<CondominioViewModel> Condominios { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

    }
}

