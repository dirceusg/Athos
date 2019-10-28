using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athos.Web.Controllers
{
    public class CondominioController : Controller
    {
        // GET: Condominio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Condominio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Condominio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Condominio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Condominio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Condominio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Condominio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}