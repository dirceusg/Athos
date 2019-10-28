using System;

namespace Athos.Entity.entities
{
    public abstract class BaseEntity
    {

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

    }
}
