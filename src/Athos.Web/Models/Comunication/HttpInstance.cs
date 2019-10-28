using System.Net.Http;

namespace Athos.Web.Models.Comunication
{
    public class HttpInstance
    {
        private static HttpClient httpClientInstance;

        private HttpInstance()
        {
        }

        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientInstance == null)
            {
                httpClientInstance = new HttpClient();
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            }
            return httpClientInstance;
        }

    }
}
