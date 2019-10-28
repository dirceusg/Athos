using Athos.Entity.entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Entity.entities
{
    public class Comunicado : BaseEntity
    {

        public DateTime DataCadastro { get; set; }
        public Guid RemetenteId { get; set; }
        public Usuario Remetente { get; set; }

        public TipoAssunto TipoAssunto { get; set; }

        public string Mensagem { get; set; }


        public IEnumerable<ComunicadoAcao> ComunicadosAcoes { get; set; }
    }
}
