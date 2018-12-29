using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAPIclient.Controllers
{
    public class HttpApiController
    {
        public static HttpClient HttpApiClient { get; set; }


        public static void InitializeClient()
        {
            HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("https://api.github.com/");
            HttpApiClient.DefaultRequestHeaders.Accept.Clear();
            HttpApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpApiClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
        }
    }
}
