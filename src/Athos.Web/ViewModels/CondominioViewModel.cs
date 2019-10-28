using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Web.ViewModels
{
    public class CondominioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        public Guid AdministradoraId { get; set; }
        public AdministradoraViewModel Administradora { get; set; }

        public UsuarioViewModel Responsavel { get; set; }

        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
        public IEnumerable<AdministradoraViewModel> Administradoras { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
    }
}
