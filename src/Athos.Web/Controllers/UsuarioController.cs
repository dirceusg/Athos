using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Athos.Web.Models.Comunication;
using Athos.Web.Services;
using Athos.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Athos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private string baseUri = "https://localhost:44329/";

        [HttpGet]
        public IActionResult Index()
        {
            CustomResponse retorno =  UsuarioService.GetAll(baseUri);
            
            List<UsuarioViewModel> ListUser = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(JsonConvert.SerializeObject(retorno.Data));

            return View(ListUser);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            CustomResponse retorno = UsuarioService.GetById(baseUri,id);

            UsuarioViewModel user = JsonConvert.DeserializeObject<UsuarioViewModel>(JsonConvert.SerializeObject(retorno.Data));

            return View(user);
        }

        public  IActionResult Create()
        {
            var usuario = PopularCondominios(new UsuarioViewModel());

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Email,TipoUsuario,CondominioId")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomResponse retorno = UsuarioService.Create(baseUri, usuarioViewModel);

                if(retorno.Success == true)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(usuarioViewModel);
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomResponse retorno = UsuarioService.GetById(baseUri, id);
            UsuarioViewModel user = JsonConvert.DeserializeObject<UsuarioViewModel>(JsonConvert.SerializeObject(retorno.Data));

            user = PopularCondominios(user);

            if (user == null)
            {
                return NotFound();
            }



            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Nome,Email,TipoUsuario,CondominioId")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomResponse retorno = UsuarioService.Update(baseUri, usuarioViewModel);

                if (retorno.Success == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuarioViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomResponse retorno = UsuarioService.GetById(baseUri, id);
            UsuarioViewModel user = JsonConvert.DeserializeObject<UsuarioViewModel>(JsonConvert.SerializeObject(retorno.Data));

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            //var usuarioViewModel = await _context.UsuarioViewModel.FindAsync(id);
            //_context.UsuarioViewModel.Remove(usuarioViewModel);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioViewModelExists(Guid id)
        {
            return true;
            //return _context.UsuarioViewModel.Any(e => e.Id == id);
        }

        protected bool OperationValid()
        {
            return true;
        }

        private UsuarioViewModel PopularCondominios(UsuarioViewModel usuario)
        {
          CustomResponse retorno = CondominioService.GetAll(baseUri);

            IEnumerable<CondominioViewModel> ListCondominio = JsonConvert.DeserializeObject<IEnumerable<CondominioViewModel>>(JsonConvert.SerializeObject(retorno.Data));

            usuario.Condominios = ListCondominio;
            return usuario;
        }

    }
}