using Athos.Web.Models.Comunication;
using Athos.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Athos.Web.Services
{
    public static class AdministradoraService
    {
        public static CustomResponse GetAll(string baseUri)
        {
            #region Request

            #region URL End Point

            string action = "api/administradora";

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUri + action);

            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            return JsonConvert.DeserializeObject<CustomResponse>(response.Content.ReadAsStringAsync().Result);


            #endregion

        }

        public static CustomResponse GetById(string baseUri, Guid id)
        {
            CustomResponse retorno = new CustomResponse();

            #region Request

            #region URL End Point

            string action = "api/administradora/" + id;

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

        public static CustomResponse Create(string baseUri, AdministradoraViewModel administradora)
        {
            #region Request

            #region URL End Point

            string action = "api/administradora";

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUri + action);

            #endregion

            #region formBody

            var json = JsonConvert.SerializeObject(administradora);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");


            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            return JsonConvert.DeserializeObject<CustomResponse>(response.Content.ReadAsStringAsync().Result);

            #endregion

        }

        public static CustomResponse Update(string baseUri, AdministradoraViewModel administradora)
        {
            #region Request

            #region URL End Point

            string action = "api/administradora/" + administradora.Id;

            #endregion

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, baseUri + action);

            #endregion

            #region formBody

            var json = JsonConvert.SerializeObject(administradora);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");


            #endregion

            #region Response

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            return JsonConvert.DeserializeObject<CustomResponse>(response.Content.ReadAsStringAsync().Result);

            #endregion

        }

    }
}
