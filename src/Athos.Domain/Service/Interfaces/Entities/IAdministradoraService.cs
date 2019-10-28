using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface IAdministradoraService : IDisposable
    {
        Task Add(Administradora entity);
        Task<Administradora> GetById(Guid id);
        Task<Administradora> GetBySearch(Expression<Func<Administradora, bool>> predicate);
        Task<List<Administradora>> GetAll();
        Task Update(Administradora entity);
        Task Delete(Guid id);
        Task<IEnumerable<Administradora>> Search(Expression<Func<Administradora, bool>> predicate);
        Task<int> SaveChanges();
    }
}
