using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPIclient.Controllers;
using WebAPIclient.enums;

namespace WebAPIclient.Processors
{
    public class GitHubProcessor
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public HttpRequestMessage request { get; set; }

        public GitHubProcessor()
        {
            endPoint = "user";
            httpMethod = httpVerb.GET;
            request = new HttpRequestMessage(new HttpMethod(httpMethod.ToString()), new Uri(HttpApiController.HttpApiClient.BaseAddress+endPoint));
        }

        public async Task MakeRequestAsync()
        {
            var byteArray = Encoding.ASCII.GetBytes("***:***");//username and password
            HttpApiController.HttpApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            using (HttpResponseMessage response = HttpApiController.HttpApiClient.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody != null)
                {
                    Console.WriteLine(responseBody);
                }
            }
        }
    }
}
