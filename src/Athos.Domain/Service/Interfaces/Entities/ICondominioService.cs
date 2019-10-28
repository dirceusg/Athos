using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface ICondominioService : IDisposable
    {
        Task Add(Condominio entity);
        Task<Condominio> GetById(Guid id);
        Task<Condominio> GetBySearch(Expression<Func<Condominio, bool>> predicate);
        Task<List<Condominio>> GetAll();
        Task Update(Condominio entity);
        Task Delete(Guid id);
        Task<IEnumerable<Condominio>> Search(Expression<Func<Condominio, bool>> predicate);
        Task<List<Condominio>> GetByAdministradora(Guid administradoraId);
        Task<int> SaveChanges();

    }
}
