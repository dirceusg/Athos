using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Athos.Web.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        public int TipoUsuario { get; set; }

        public Guid CondominioId { get; set; }

        public CondominioViewModel Condominio;

        public IEnumerable<CondominioViewModel> Condominios { get; set; }

    }
}
