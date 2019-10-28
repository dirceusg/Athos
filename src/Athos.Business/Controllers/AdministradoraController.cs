using Athos.Business.ViewModels;
using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Entity.entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athos.Business.Controllers
{
    [Route("api/[controller]")]
    public class AdministradoraController : MainController
    {
        private readonly IAdministradoraService _dbAdministradora;
        private readonly IMapper _mapper;

        public AdministradoraController(INotification notifier,
                                        IAdministradoraService dbAdministradora,
                                        IMapper mapper):base(notifier)
        {
            _dbAdministradora = dbAdministradora;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Administradora.", Tags = new[] { "Administradora" })]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministradoraViewModel>>> GetAll()
        {
            var listaAdministradora = _mapper.Map<IEnumerable<AdministradoraViewModel>>(await _dbAdministradora.GetAll());
            return CustomResponse(listaAdministradora);
        }

        [SwaggerOperation(Summary = "Recuperar uma Administradora.", Tags = new[] { "Administradora" })]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AdministradoraViewModel>> GetById(Guid id)
        {
            var administradora = _mapper.Map<AdministradoraViewModel>(await _dbAdministradora.GetById(id));

            if (administradora == null) return NotFound();

            return CustomResponse(administradora);
        }

        [SwaggerOperation(Summary = "Gravar uma nova Administradora.", Tags = new[] { "Administradora" })]
        [HttpPost]
        public async Task<ActionResult<AdministradoraViewModel>> Create(AdministradoraViewModel administradoraViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbAdministradora.Add(_mapper.Map<Administradora>(administradoraViewModel));

            return CustomResponse(administradoraViewModel);

        }

        [SwaggerOperation(Summary = "Editar uma Administradora.", Tags = new[] { "Administradora" })]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AdministradoraViewModel>> Update([FromRoute] Guid id,[FromBody] AdministradoraViewModel administradoraViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != administradoraViewModel.Id)
            {
                NotifierError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(administradoraViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbAdministradora.Update(_mapper.Map<Administradora>(administradoraViewModel));

            return CustomResponse(administradoraViewModel);

        }

        [SwaggerOperation(Summary = "Excluir uma Administradora.", Tags = new[] { "Administradora" })]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AdministradoraViewModel>> Delete([FromRoute] Guid id)
        {

            var administradora = _dbAdministradora.GetById(id);

            if (administradora == null) return NotFound();

            await _dbAdministradora.Delete(id);

            return CustomResponse(administradora);

            
        }

    }
}