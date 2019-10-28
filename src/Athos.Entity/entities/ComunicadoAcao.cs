using Athos.Entity.entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Entity.entities
{
    public class ComunicadoAcao : BaseEntity
    {
        public DateTime DataAcao { get; set; }

        public Guid ComunicadoId { get; set; }
        public Comunicado Comunicado { get; set; }

        public TipoAcaoComunicado TipoAcaoComunicado { get; set; }
        public Guid ExecutorId { get; set; }
        public Usuario Executor { get; set; }


    }
}
