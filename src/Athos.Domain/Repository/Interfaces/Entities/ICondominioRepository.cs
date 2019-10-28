using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athos.Domain.Repository.Interfaces.Entities
{
    public interface ICondominioRepository
        : IBaseRepository<Condominio>
    {
        Task<List<Condominio>> GetByAdministradora(Guid administradoraId);
        Task<List<Condominio>> GetCondominioAdministradora(Guid id);
    }
}
