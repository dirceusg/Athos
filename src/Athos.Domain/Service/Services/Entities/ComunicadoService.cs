using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Domain.Validation;
using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Services.Entities
{
    public class ComunicadoService : BaseService , IComunicadoService
    {
        private readonly IComunicadoRepository _dbComunicado;

        public ComunicadoService(IComunicadoRepository repository,
                                     INotification notification) : base(notification)
        {
            _dbComunicado = repository;


        }


        public async Task<Comunicado> Add(Comunicado entity)
        {
            if (!RunValidation(new ComunicadoValidation(), entity)) return null;

            await _dbComunicado.Add(entity);

            return entity; 
        }

        public async Task Update(Comunicado entity)
        {
            if (!RunValidation(new ComunicadoValidation(), entity)) return;

            await _dbComunicado.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _dbComunicado.Delete(id);
        }

        public void Dispose()
        {
            _dbComunicado?.Dispose();
        }

        public async Task<List<Comunicado>> GetAll()
        {
            return await _dbComunicado.GetAll();
        }

        public async Task<Comunicado> GetById(Guid id)
        {
            return await _dbComunicado.GetById(id);
        }

        public async Task<Comunicado> GetBySearch(Expression<Func<Comunicado, bool>> predicate)
        {
            return await _dbComunicado.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbComunicado.SaveChanges();
        }

        public async Task<IEnumerable<Comunicado>> Search(Expression<Func<Comunicado, bool>> predicate)
        {
            return await _dbComunicado.Search(predicate);
        }
    }
}
