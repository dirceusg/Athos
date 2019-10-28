using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Business.ViewModels
{
    public class ComunicadoViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public Guid RemetenteId { get; set; }
        public UsuarioViewModel Remetente { get; set; }

        public int TipoAssunto { get; set; }

        public string Mensagem { get; set; }
        public IEnumerable<ComunicadoAcaoViewModel> ComunicadosAcoes { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
    }
}
