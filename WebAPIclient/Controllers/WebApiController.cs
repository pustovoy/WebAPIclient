using System.Net;

namespace WebAPIclient.Controllers
{
    class WebApiController
    {
        public static WebClient WebApiClient { get; set; }

        public static void InitializeClient()
        {
            WebApiClient = new WebClient();
        }
    }
}
