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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Email,TipoUsuario,CondominioId")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                //usuarioViewModel.Id = Guid.NewGuid();
                //_context.Add(usuarioViewModel);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
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

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Nome,Email,TipoUsuario,CondominioId")] UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(usuarioViewModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UsuarioViewModelExists(usuarioViewModel.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
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

        // POST: UsuarioViewModels/Delete/5
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

    }
}