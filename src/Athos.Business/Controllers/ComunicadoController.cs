using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athos.Business.ViewModels;
using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Entity.entities;
using Athos.Entity.entities.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Athos.Business.Controllers
{
    [Route("api/[controller]")]
    public class ComunicadoController : MainController
    {
        private readonly IUsuarioService _dbUsuario;
        private readonly IComunicadoService _dbComunicado;
        private readonly IComunicadoAcaoService _dbComunicadoAcao;
        private readonly IAssuntoService _dbAssunto;
        private readonly IMapper _mapper;


        public ComunicadoController(IUsuarioService dbUsuario,
                                    IComunicadoService dbComunicado,
                                    IComunicadoAcaoService dbComunicadoAcao,
                                    IAssuntoService dbAssunto,
                                    INotification notifier,
                                    IMapper mapper) : base(notifier)
        {
            _mapper = mapper;
            _dbComunicado = dbComunicado;
            _dbComunicadoAcao = dbComunicadoAcao;
            _dbAssunto = dbAssunto;
            _dbUsuario = dbUsuario;

        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Comunicados.", Tags = new[] { "Mensageria" })]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> GetAll()
        {
            var listaComunicado = _mapper.Map<IEnumerable<ComunicadoViewModel>>(await _dbComunicado.GetAll());

            return CustomResponse(listaComunicado);

        }

        [SwaggerOperation(Summary = "Recuperar uma coleção de Comunicados por Remetente.", Tags = new[] { "Mensageria" })]
        [HttpGet("buscar-por-remetente/{id:guid}")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> GetAllByUserId(Guid id)
        {
            var listaComunicado = _mapper.Map<IEnumerable<ComunicadoViewModel>>(await _dbComunicado.Search(x => x.RemetenteId == id));

            return CustomResponse(listaComunicado);

        }

        [SwaggerOperation(Summary = "Criar Comunicado.", Tags = new[] { "Mensageria" })]
        [HttpPost("criar-comunicado")]
        public async Task<ActionResult<ComunicadoViewModel>> CreateMessage([FromBody] ComunicadoViewModel comunicado)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var meuComunicado = await _dbComunicado.Add(_mapper.Map<Comunicado>(comunicado));

            return CustomResponse(meuComunicado);

        }


        [SwaggerOperation(Summary = "Recuperar uma coleção de Comunicados.", Tags = new[] { "Mensageria" })]
        [HttpGet("bucar-comunicado-por-tipo/{id:int}")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> GetMessageByType([FromRoute] int id)
        {

            TipoAssunto tipoAssunto = TipoAssunto.Administrativo;

            if (id != 1)
            {
                tipoAssunto = TipoAssunto.Condominial;
            }
            
            var listaComunicado = _mapper.Map<IEnumerable<ComunicadoViewModel>>(await _dbComunicado.Search(x=>x.TipoAssunto == tipoAssunto));

            return CustomResponse(listaComunicado);

        }



    }
}