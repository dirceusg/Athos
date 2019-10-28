using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Domain.Validation;
using Athos.Entity.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Domain.Service.Services.Entities
{
    public class CondominioService : BaseService, ICondominioService
    {

        private readonly ICondominioRepository _dbCondominio;
        private readonly IUsuarioRepository _dbUsuario;


        public CondominioService(ICondominioRepository repository,
                                 IUsuarioRepository dbUsuario,
                                     INotification notification) : base(notification)
        {
            _dbCondominio = repository;
            _dbUsuario = dbUsuario;

        }


        public async Task Add(Condominio entity)
        {
            if (!RunValidation(new CondominioValidation(), entity)) return;

            if (_dbCondominio.Search(x => x.Nome == entity.Nome).Result.Any())
            {
                Notify("Já existe um Condominio com este Nome informado.");
                return;
            }

            await _dbCondominio.Add(entity);
        }

        public async Task Update(Condominio entity)
        {
            if (!RunValidation(new CondominioValidation(), entity)) return;

            if (_dbCondominio.Search(x => x.Nome == entity.Nome || x.Id != entity.Id).Result.Any())
            {
                Notify("Já existe um Condominio com este Nome informado.");
                return;
            }

            await _dbCondominio.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            if (_dbUsuario.GetByCondominio(id).Result.Any())
            {
                Notify("O Condominio possui Usuários cadastrados!");
                return;
            }

            await _dbCondominio.Delete(id);
        }

        public void Dispose()
        {
            _dbCondominio?.Dispose();
        }

        public async Task<List<Condominio>> GetAll()
        {
            return await _dbCondominio.GetAll();
        }

        public async Task<Condominio> GetById(Guid id)
        {
            return await _dbCondominio.GetById(id);
        }

        public async Task<Condominio> GetBySearch(Expression<Func<Condominio, bool>> predicate)
        {
            return await _dbCondominio.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbCondominio.SaveChanges();
        }

        public async Task<IEnumerable<Condominio>> Search(Expression<Func<Condominio, bool>> predicate)
        {
            return await _dbCondominio.Search(predicate);
        }

        public Task<List<Condominio>> GetByAdministradora(Guid administradoraId)
        {
            return _dbCondominio.GetByAdministradora(administradoraId);
        }
    }
}
