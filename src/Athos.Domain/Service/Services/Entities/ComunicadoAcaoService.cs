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
    public class ComunicadoAcaoService : BaseService, IComunicadoAcaoService
    {
        private readonly IComunicadoAcaoRepository _dbComunicadoAcao;

        public ComunicadoAcaoService(IComunicadoAcaoRepository repository,
                                     INotification notification) : base(notification)
        {
            _dbComunicadoAcao = repository;


        }


        public async Task Add(ComunicadoAcao entity)
        {
            if (!RunValidation(new ComunicadoAcaoValidation(), entity)) return;

            await _dbComunicadoAcao.Add(entity);
        }

        public async Task Update(ComunicadoAcao entity)
        {
            if (!RunValidation(new ComunicadoAcaoValidation(), entity)) return;

            await _dbComunicadoAcao.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _dbComunicadoAcao.Delete(id);
        }

        public void Dispose()
        {
            _dbComunicadoAcao?.Dispose();
        }

        public async Task<List<ComunicadoAcao>> GetAll()
        {
            return await _dbComunicadoAcao.GetAll();
        }

        public async Task<ComunicadoAcao> GetById(Guid id)
        {
            return await _dbComunicadoAcao.GetById(id);
        }

        public async Task<ComunicadoAcao> GetBySearch(Expression<Func<ComunicadoAcao, bool>> predicate)
        {
            return await _dbComunicadoAcao.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbComunicadoAcao.SaveChanges();
        }

        public async Task<IEnumerable<ComunicadoAcao>> Search(Expression<Func<ComunicadoAcao, bool>> predicate)
        {
            return await _dbComunicadoAcao.Search(predicate);
        }
    }
}
