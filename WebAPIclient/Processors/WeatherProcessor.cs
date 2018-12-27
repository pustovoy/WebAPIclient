using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIclient.Controllers;
using WebAPIclient.Models;

namespace WebAPIclient.Processors
{
    public class WeatherProcessor
    {
        public static async Task<WeatherModel> LoadWeatherAsync(string city)
        {
            string url;
            url = city != default ? $"api.openweathermap.org/data/2.5/weather?q={city}" : $"api.openweathermap.org/data/2.5/weather?q=London";

            using (HttpResponseMessage response = await ApiController.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    WeatherModel weather = await response.Content.ReadAsAsync<WeatherModel>();
                    return weather;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
