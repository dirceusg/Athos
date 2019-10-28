using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Repository.Context;

namespace Athos.Repository.Repository.Entities
{
    public class AssuntoRepository : Repository<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(AthosDbContext context):base(context)
        {

        }
    }
}
