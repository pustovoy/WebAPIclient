using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPIclient.Controllers;
using WebAPIclient.Models;
using WebAPIclient.Services;

namespace WebAPIclient.Processors
{
    public class WeatherProcessor
    {
        public static async Task<ModelList> LoadWeatherAsync(string city, int count)
        {
            var url = city != "" ? $"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&cnt={count}&APPID=c78041785ed9e31d95b0f8fe7cfe1221" : $"http://api.openweathermap.org/data/2.5/forecast?q=London&units=metric&APPID=c78041785ed9e31d95b0f8fe7cfe1221";
            try
            {
                var response = await WebApiController.WebApiClient.DownloadStringTaskAsync(url);            
                return JsonConvert.DeserializeObject<ModelList>(response);
            }
            catch (Exception e)
            {
                ErrorLogService.StoreErrorLog(e.ToString());
            }
            return null;
        }
    }
}
