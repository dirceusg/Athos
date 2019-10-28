using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface IAssuntoService : IDisposable
    {
        Task Add(Assunto entity);
        Task<Assunto> GetById(Guid id);
        Task<Assunto> GetBySearch(Expression<Func<Assunto, bool>> predicate);
        Task<List<Assunto>> GetAll();
        Task Update(Assunto entity);
        Task Delete(Guid id);
        Task<IEnumerable<Assunto>> Search(Expression<Func<Assunto, bool>> predicate);
        Task<int> SaveChanges();
    }
}
