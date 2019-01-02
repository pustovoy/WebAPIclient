using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPIclient.Controllers;
using WebAPIclient.enums;
using WebAPIclient.Models;

namespace WebAPIclient.Processors
{
    public class GitHubProcessor
    {
        public string EndPoint { get; set; }
        public httpVerb HttpMethod { get; set; }
        public HttpRequestMessage Request { get; set; }

        public GitHubProcessor()
        {
            EndPoint = "user";
            HttpMethod = httpVerb.GET;
            Request = new HttpRequestMessage(new HttpMethod(HttpMethod.ToString()), new Uri(HttpApiController.HttpApiClient.BaseAddress+EndPoint));
        }

        public async Task GetAsync()
        {
            var byteArray = Encoding.ASCII.GetBytes("pustovoy:");//username and password
            HttpApiController.HttpApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            using (HttpResponseMessage response = HttpApiController.HttpApiClient.SendAsync(Request).Result)
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

        public async Task PatchAsync()
        {
            SetRequest("user", "PATCH");
            var byteArray = Encoding.ASCII.GetBytes("pustovoy:Student1036467");//username and password
            HttpApiController.HttpApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            using (HttpResponseMessage response = HttpApiController.HttpApiClient.SendAsync(Request).Result)
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

        public void SetRequest(string endpoint, string method)
        {
            UserModel pp = new UserModel();
            pp.Name = "testtest";
            Request = new HttpRequestMessage(new HttpMethod(method), new Uri(HttpApiController.HttpApiClient.BaseAddress + endpoint))
            {
               // Content = new StringContent(JsonConvert.)
                Content = new ObjectContent<UserModel>(new UserModel(), new UTF8Encoding(false))
            };


        }
    }
}
