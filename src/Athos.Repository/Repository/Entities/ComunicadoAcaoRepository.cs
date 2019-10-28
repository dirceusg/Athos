using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Repository.Context;

namespace Athos.Repository.Repository.Entities
{
    public class ComunicadoAcaoRepository : Repository<ComunicadoAcao> , IComunicadoAcaoRepository
    {
        public ComunicadoAcaoRepository(AthosDbContext context) : base(context)
        {

        }
    }
}
