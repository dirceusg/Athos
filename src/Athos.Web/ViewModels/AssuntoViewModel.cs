using System;
using System.ComponentModel.DataAnnotations;

namespace Athos.Web.ViewModels
{
    public class AssuntoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public int TipoAssunto { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
    }
}
