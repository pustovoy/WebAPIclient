using Newtonsoft.Json;

namespace WebAPIclient.Models
{
    public class CityModel
    {
        [JsonProperty("name")]
        public string CityName { get; set; }
    }
}
