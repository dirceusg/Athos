using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Interfaces.Entities
{
    public interface IUsuarioService : IDisposable
    {
        Task Add(Usuario entity);
        Task<Usuario> GetById(Guid id);
        Task<Usuario> GetBySearch(Expression<Func<Usuario, bool>> predicate);
        Task<List<Usuario>> GetAll();
        Task Update(Usuario entity);
        Task Delete(Guid id);
        Task<IEnumerable<Usuario>> Search(Expression<Func<Usuario, bool>> predicate);
        Task<List<Usuario>> GetByCondominio(Guid condominioId);
        Task<int> SaveChanges();
    }
}
