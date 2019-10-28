using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Repository.Context;

namespace Athos.Repository.Repository.Entities
{
    public class AdministradoraRepository : Repository<Administradora>, IAdministradoraRepository
    {
        public AdministradoraRepository(AthosDbContext context):base(context)
        {

        }
    }
}
