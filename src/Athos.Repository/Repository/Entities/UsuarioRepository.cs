using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Repository.Repository.Entities
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AthosDbContext context) : base (context)
        {

        }

        public async Task<IEnumerable<Usuario>> GetByCondominio(Guid condominioId)
        {
            return await Db.Usuario
                   .Where(x => x.CondominioId == condominioId)
                   .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioCondominio(Guid id)
        {
            return await Db.Usuario
                .Where(x => x.CondominioId == id)
                .AsNoTracking()
                .Include(c => c.Condominio)
                .ToListAsync();
        }
    }
}
