using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athos.Web.Models.Comunication;
using Athos.Web.Services;
using Athos.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Athos.Web.Controllers
{
    public class CondominioController : Controller
    {
        private string baseUri = "https://localhost:44329/";

        [HttpGet]
        public IActionResult Index()
        {
            CustomResponse retorno = CondominioService.GetAll(baseUri);

            List<CondominioViewModel> ListUser = JsonConvert.DeserializeObject<List<CondominioViewModel>>(JsonConvert.SerializeObject(retorno.Data));

            return View(ListUser);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            CustomResponse retorno = CondominioService.GetById(baseUri, id);

            CondominioViewModel user = JsonConvert.DeserializeObject<CondominioViewModel>(JsonConvert.SerializeObject(retorno.Data));

            return View(user);
        }

        public IActionResult Create()
        {
            var Condominio = PopularAdministradoras(new CondominioViewModel());

            return View(Condominio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,AdminsitradoraId,Administradora,Responsavel,Ativo, Excluido")] CondominioViewModel CondominioViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomResponse retorno = CondominioService.Create(baseUri, CondominioViewModel);

                if (retorno.Success == true)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(CondominioViewModel);
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomResponse retorno = CondominioService.GetById(baseUri, id);
            CondominioViewModel user = JsonConvert.DeserializeObject<CondominioViewModel>(JsonConvert.SerializeObject(retorno.Data));

            user = PopularAdministradoras(user);

            if (user == null)
            {
                return NotFound();
            }



            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Nome,AdminsitradoraId,Administradora,Responsavel,Ativo, Excluido")] CondominioViewModel CondominioViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomResponse retorno = CondominioService.Update(baseUri, CondominioViewModel);

                if (retorno.Success == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(CondominioViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomResponse retorno = CondominioService.GetById(baseUri, id);
            CondominioViewModel user = JsonConvert.DeserializeObject<CondominioViewModel>(JsonConvert.SerializeObject(retorno.Data));

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
            //var CondominioViewModel = await _context.CondominioViewModel.FindAsync(id);
            //_context.CondominioViewModel.Remove(CondominioViewModel);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondominioViewModelExists(Guid id)
        {
            return true;
            //return _context.CondominioViewModel.Any(e => e.Id == id);
        }

        protected bool OperationValid()
        {
            return true;
        }

        private CondominioViewModel PopularAdministradoras(CondominioViewModel Condominio)
        {
            CustomResponse retorno = AdministradoraService.GetAll(baseUri);

            IEnumerable<AdministradoraViewModel> ListAdministradora = JsonConvert.DeserializeObject<IEnumerable<AdministradoraViewModel>>(JsonConvert.SerializeObject(retorno.Data));

            Condominio.Administradoras = ListAdministradora;
            return Condominio;
        }
    }
}