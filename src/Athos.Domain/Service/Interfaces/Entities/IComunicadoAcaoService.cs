using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface IComunicadoAcaoService : IDisposable
    {
        Task Add(ComunicadoAcao entity);
        Task<ComunicadoAcao> GetById(Guid id);
        Task<ComunicadoAcao> GetBySearch(Expression<Func<ComunicadoAcao, bool>> predicate);
        Task<List<ComunicadoAcao>> GetAll();
        Task Update(ComunicadoAcao entity);
        Task Delete(Guid id);
        Task<IEnumerable<ComunicadoAcao>> Search(Expression<Func<ComunicadoAcao, bool>> predicate);
        Task<int> SaveChanges();
    }
}
