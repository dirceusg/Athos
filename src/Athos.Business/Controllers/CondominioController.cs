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
    public class CondominioController : MainController
    {
        private readonly ICondominioService _dbCondominio;
        private readonly IMapper _mapper;

        public CondominioController(INotification notifier,
                                        ICondominioService dbCondominio,
                                        IMapper mapper) : base(notifier)
        {
            _dbCondominio = dbCondominio;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Condominio.", Tags = new[] { "Condominio" })]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CondominioViewModel>>> GetAll()
        {
            var listaCondominio = _mapper.Map<IEnumerable<CondominioViewModel>>(await _dbCondominio.GetAll());
            return CustomResponse(listaCondominio);
        }

        [SwaggerOperation(Summary = "Recuperar uma Condominio.", Tags = new[] { "Condominio" })]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> GetById(Guid id)
        {
            var Condominio = _mapper.Map<CondominioViewModel>(await _dbCondominio.GetById(id));

            if (Condominio == null) return NotFound();

            return CustomResponse(Condominio);
        }

        [SwaggerOperation(Summary = "Gravar uma nova Condominio.", Tags = new[] { "Condominio" })]
        [HttpPost]
        public async Task<ActionResult<CondominioViewModel>> Create(CondominioViewModel CondominioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbCondominio.Add(_mapper.Map<Condominio>(CondominioViewModel));

            return CustomResponse(CondominioViewModel);

        }

        [SwaggerOperation(Summary = "Editar uma Condominio.", Tags = new[] { "Condominio" })]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> Update([FromRoute] Guid id, [FromBody] CondominioViewModel CondominioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != CondominioViewModel.Id)
            {
                NotifierError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(CondominioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbCondominio.Update(_mapper.Map<Condominio>(CondominioViewModel));

            return CustomResponse(CondominioViewModel);

        }

        [SwaggerOperation(Summary = "Excluir uma Condominio.", Tags = new[] { "Condominio" })]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> Delete([FromRoute] Guid id)
        {

            var Condominio = _dbCondominio.GetById(id);

            if (Condominio == null) return NotFound();

            await _dbCondominio.Delete(id);

            return CustomResponse(Condominio);


        }
    }
}