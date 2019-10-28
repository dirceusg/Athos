using System.Collections.Generic;

namespace Athos.Entity.entities
{
    public class Administradora : BaseEntity
    {
        public string Nome { get; set; }

        public IEnumerable<Condominio> Condominios { get; set; }

    }
}
