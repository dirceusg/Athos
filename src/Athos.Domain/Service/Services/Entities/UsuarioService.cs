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
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _dbUsuario;



        public UsuarioService(IUsuarioRepository repository,
                                     INotification notification) : base(notification)
        {
            _dbUsuario = repository;

        }


        public async Task Add(Usuario entity)
        {
            if (!RunValidation(new UsuarioValidation(), entity)) return;

            if (_dbUsuario.Search(x => x.Nome == entity.Nome).Result.Any())
            {
                Notify("Já existe um Usuario com este Nome informado.");
                return;
            }

            await _dbUsuario.Add(entity);
        }

        public async Task Update(Usuario entity)
        {
            if (!RunValidation(new UsuarioValidation(), entity)) return;

            if (_dbUsuario.Search(x => x.Nome == entity.Nome || x.Id != entity.Id).Result.Any())
            {
                Notify("Já existe um Usuario com este Nome informado.");
                return;
            }

            await _dbUsuario.Update(entity);
        }

        public async Task Delete(Guid id)
        {
            await _dbUsuario.Delete(id);
        }

        public void Dispose()
        {
            _dbUsuario?.Dispose();
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _dbUsuario.GetAll();
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _dbUsuario.GetById(id);
        }

        public async Task<Usuario> GetBySearch(Expression<Func<Usuario, bool>> predicate)
        {
            return await _dbUsuario.GetBySearch(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbUsuario.SaveChanges();
        }

        public async Task<IEnumerable<Usuario>> Search(Expression<Func<Usuario, bool>> predicate)
        {
            return await _dbUsuario.Search(predicate);
        }

        public async Task<List<Usuario>> GetByCondominio(Guid condominioId)
        {
            return (await _dbUsuario.Search(x => x.CondominioId == condominioId)).ToList();
            
        }
    }
}
