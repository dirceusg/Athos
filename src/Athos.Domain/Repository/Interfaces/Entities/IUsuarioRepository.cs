using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athos.Domain.Repository.Interfaces.Entities
{
    public interface IUsuarioRepository
        : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetByCondominio(Guid condominioId);
        Task<IEnumerable<Usuario>> GetUsuarioCondominio(Guid id);

    }
}
