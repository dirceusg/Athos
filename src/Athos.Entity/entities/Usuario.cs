using Athos.Entity.entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Entity.entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Guid CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        public IEnumerable<Comunicado> Comunicados { get; set; }
        public IEnumerable<ComunicadoAcao> ComunicadosAcoes { get; set; }
        

    }
}
