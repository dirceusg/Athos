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
    public class CondominioRepository : Repository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(AthosDbContext context):base(context)
        {

        }

        public async Task<List<Condominio>> GetByAdministradora(Guid administradoraId)
        {
            return await Db.Condominio
                   .Where(x=>x.AdministradoraId == administradoraId)
                   .ToListAsync();
        }

        public async Task<List<Condominio>> GetCondominioAdministradora(Guid id)
        {
            return await Db.Condominio
                .Where(x => x.AdministradoraId == id)
                .AsNoTracking()
                .Include(c => c.administradora)
                .ToListAsync();
        }
    }
}
