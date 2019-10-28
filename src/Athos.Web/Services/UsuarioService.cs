using Athos.Web.Models.Comunication;
using Athos.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Athos.Web.Services
{
    public static class UsuarioService
    {
        public static CustomResponse GetAll(string baseUri)
        {
            #region Request

            #region URL End Point

            string action = "api/usuario";

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + action);

            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            return JsonConvert.DeserializeObject<CustomResponse>(response.Content.ReadAsStringAsync().Result);

       
            #endregion

        }

        public static CustomResponse GetById(string baseUri,Guid id)
        {
            CustomResponse retorno = new CustomResponse();

            #region Request

            #region URL End Point

            string action = "api/usuario/" + id;

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + action);

            #endregion

            #region formPost



            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            return JsonConvert.DeserializeObject<CustomResponse>(response.Content.ReadAsStringAsync().Result);


            #endregion

        }
    }
}
