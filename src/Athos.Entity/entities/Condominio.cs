using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Entity.entities
{
    public class Condominio : BaseEntity
    {
        public string Nome { get; set; }

        public Guid AdministradoraId { get; set; }
        public Administradora administradora { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }


    }
}
