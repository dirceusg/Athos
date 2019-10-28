using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface IComunicadoService : IDisposable
    {
        Task<Comunicado> Add(Comunicado entity);
        Task<Comunicado> GetById(Guid id);
        Task<Comunicado> GetBySearch(Expression<Func<Comunicado, bool>> predicate);
        Task<List<Comunicado>> GetAll();
        Task Update(Comunicado entity);
        Task Delete(Guid id);
        Task<IEnumerable<Comunicado>> Search(Expression<Func<Comunicado, bool>> predicate);
        Task<int> SaveChanges();
    }
}
