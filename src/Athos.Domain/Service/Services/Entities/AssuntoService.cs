using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Domain.Validation;
using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Services.Entities
{
    public class AssuntoService : BaseService, IAssuntoService
    {
        private readonly IAssuntoRepository _dbAssunto;

        public AssuntoService(IAssuntoRepository repository,
                                     INotification notification) : base(notification)
        {
            _dbAssunto = repository;


        }


        public async Task Add(Assunto entity)
        {
            if (!RunValidation(new AssuntoValidation(), entity)) return;

            await _dbAssunto.Add(entity);
        }

        public async Task Update(Assunto entity)
        {
            if (!RunValidation(new AssuntoValidation(), entity)) return;

            await _dbAssunto.Update(entity);
        }

        public async Task Delete(Guid id)
        {   
            await _dbAssunto.Delete(id);
        }

        public void Dispose()
        {
            _dbAssunto?.Dispose();
        }

        public async Task<List<Assunto>> GetAll()
        {
            return await _dbAssunto.GetAll();
        }

        public async Task<Assunto> GetById(Guid id)
        {
            return await _dbAssunto.GetById(id);
        }

        public async Task<Assunto> GetBySearch(Expression<Func<Assunto, bool>> predicate)
        {
            return await _dbAssunto.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbAssunto.SaveChanges();
        }

        public async Task<IEnumerable<Assunto>> Search(Expression<Func<Assunto, bool>> predicate)
        {
            return await _dbAssunto.Search(predicate);
        }

    }
}
