using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Repository.Context;

namespace Athos.Repository.Repository.Entities
{
    public class ComunicadoRepository : Repository<Comunicado> , IComunicadoRepository
    {
        public ComunicadoRepository(AthosDbContext context):base(context)
        {

        }
    }
}
