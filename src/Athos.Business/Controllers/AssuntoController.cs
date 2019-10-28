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
    public class AssuntoController : MainController
    {
        private readonly IAssuntoService _dbAssunto;
        private readonly IMapper _mapper;

        public AssuntoController(INotification notifier,
                                        IAssuntoService dbAssunto,
                                        IMapper mapper) : base(notifier)
        {
            _dbAssunto = dbAssunto;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Assunto.", Tags = new[] { "Assunto" })]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoViewModel>>> GetAll()
        {
            var listaAssunto = _mapper.Map<IEnumerable<AssuntoViewModel>>(await _dbAssunto.GetAll());
            return CustomResponse(listaAssunto);
        }

        [SwaggerOperation(Summary = "Recuperar uma Assunto.", Tags = new[] { "Assunto" })]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AssuntoViewModel>> GetById(Guid id)
        {
            var Assunto = _mapper.Map<AssuntoViewModel>(await _dbAssunto.GetById(id));

            if (Assunto == null) return NotFound();

            return CustomResponse(Assunto);
        }

        [SwaggerOperation(Summary = "Gravar uma nova Assunto.", Tags = new[] { "Assunto" })]
        [HttpPost]
        public async Task<ActionResult<AssuntoViewModel>> Create(AssuntoViewModel AssuntoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbAssunto.Add(_mapper.Map<Assunto>(AssuntoViewModel));

            return CustomResponse(AssuntoViewModel);

        }

        [SwaggerOperation(Summary = "Editar uma Assunto.", Tags = new[] { "Assunto" })]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AssuntoViewModel>> Update([FromRoute] Guid id, [FromBody] AssuntoViewModel AssuntoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != AssuntoViewModel.Id)
            {
                NotifierError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(AssuntoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _dbAssunto.Update(_mapper.Map<Assunto>(AssuntoViewModel));

            return CustomResponse(AssuntoViewModel);

        }

        [SwaggerOperation(Summary = "Excluir uma Assunto.", Tags = new[] { "Assunto" })]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AssuntoViewModel>> Delete([FromRoute] Guid id)
        {

            var Assunto = _dbAssunto.GetById(id);

            if (Assunto == null) return NotFound();

            await _dbAssunto.Delete(id);

            return CustomResponse(Assunto);


        }
    }
}