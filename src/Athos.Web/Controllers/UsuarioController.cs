using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Athos.Web.Models.Comunication;
using Athos.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Athos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private string baseUri = "https://localhost:44329/";


        public IActionResult ListarUsuarios()
        {
            #region Request

            #region URL End Point

            string action = "api/usuario";

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + action);

            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            JObject userJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            #region Retorno Response

            if (response.IsSuccessStatusCode)
            {
                var success = userJson["success"].ToString();
                var message = userJson["message"].ToString();

                var json = JsonConvert.SerializeObject(userJson["data"]);
                List<UsuarioViewModel> retorno = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(json);

                ViewBag.ListaUsuarios = retorno;
            }

            #endregion

            #endregion

            return View();
        }
    }
}