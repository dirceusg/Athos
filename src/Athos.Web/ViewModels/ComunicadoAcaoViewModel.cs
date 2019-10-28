using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Web.ViewModels
{
    public class ComunicadoAcaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataAcao { get; set; }

        public Guid ComunicadoId { get; set; }
        public ComunicadoViewModel Comunicado { get; set; }

        public int TipoAcaoComunicado { get; set; }
        public Guid ExecutorId { get; set; }
        public UsuarioViewModel Executor { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

    }
}
