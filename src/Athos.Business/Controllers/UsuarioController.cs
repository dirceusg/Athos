using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athos.Business.ViewModels;
using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Entity.entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Athos.Business.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _dbUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(INotification notifier,
                                        IUsuarioService dbUsuario,
                                        IMapper mapper) : base(notifier)
        {
            _dbUsuario = dbUsuario;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Usuario.", Tags = new[] { "Usuario" })]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> GetAll()
        {
            var listaUsuario = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _dbUsuario.GetAll());
            return CustomResponse(listaUsuario);
        }

        [SwaggerOperation(Summary = "Recuperar uma Usuario.", Tags = new[] { "Usuario" })]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> GetById(Guid id)
        {
            var Usuario = _mapper.Map<UsuarioViewModel>(await _dbUsuario.GetById(id));

            if (Usuario == null) return NotFound();

            return CustomResponse(Usuario);
        }

        [SwaggerOperation(Summary = "Gravar uma nova Usuario.", Tags = new[] { "Usuario" })]
        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Create(UsuarioViewModel UsuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbUsuario.Add(_mapper.Map<Usuario>(UsuarioViewModel));

            return CustomResponse(UsuarioViewModel);

        }

        [SwaggerOperation(Summary = "Editar uma Usuario.", Tags = new[] { "Usuario" })]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Update([FromRoute] Guid id, [FromBody] UsuarioViewModel UsuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != UsuarioViewModel.Id)
            {
                NotifierError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(UsuarioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbUsuario.Update(_mapper.Map<Usuario>(UsuarioViewModel));

            return CustomResponse(UsuarioViewModel);

        }

        [SwaggerOperation(Summary = "Excluir uma Usuario.", Tags = new[] { "Usuario" })]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Delete([FromRoute] Guid id)
        {

            var Usuario = _dbUsuario.GetById(id);

            if (Usuario == null) return NotFound();

            await _dbUsuario.Delete(id);

            return CustomResponse(Usuario);


        }
    }
}