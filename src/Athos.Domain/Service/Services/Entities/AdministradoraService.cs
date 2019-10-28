using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Domain.Validation;
using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Services.Entities
{
    public class AdministradoraService : BaseService, IAdministradoraService
    {
        private readonly IAdministradoraRepository _dbAdministradora;
        private readonly ICondominioRepository _dbCondominio;

        public AdministradoraService(IAdministradoraRepository repository, 
                                     ICondominioRepository dbCondominio,
                                     INotification notification) : base(notification)
        {
            _dbAdministradora = repository;
            _dbCondominio = dbCondominio;

        }

        public async Task Add(Administradora entity)
        {
            if (!RunValidation(new AdministradoraValidation(), entity)) return;

            if(_dbAdministradora.Search(x=>x.Nome == entity.Nome).Result.Any())
            {
                Notify("Já existe uma Administradora com este Nome informado.");
                return;
            }

            await _dbAdministradora.Add(entity);
        }

        public async Task Update(Administradora entity)
        {
            if (!RunValidation(new AdministradoraValidation(), entity)) return;

            if (_dbAdministradora.Search(x => x.Nome == entity.Nome && x.Id != entity.Id).Result.Any())
            {
                Notify("Já existe uma Administradora com este Nome informado.");
                return;
            }

            await _dbAdministradora.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            if (_dbCondominio.GetByAdministradora(id).Result.Any())
            {
                Notify("A Administradora possui Condominios cadastrados!");
                return;
            }
            await _dbAdministradora.Delete(id);
        }

        public void Dispose()
        {
            _dbAdministradora?.Dispose();
            _dbCondominio?.Dispose();
        }

        public async Task<List<Administradora>> GetAll()
        {
            return await _dbAdministradora.GetAll();
        }

        public async Task<Administradora> GetById(Guid id)
        {
            return await _dbAdministradora.GetById(id);
        }

        public async Task<Administradora> GetBySearch(Expression<Func<Administradora, bool>> predicate)
        {
            return await _dbAdministradora.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbAdministradora.SaveChanges();
        }

        public async Task<IEnumerable<Administradora>> Search(Expression<Func<Administradora, bool>> predicate)
        {
            return await _dbAdministradora.Search(predicate);
        }

       
    }
}
