using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebAPIclient.Models
{
    public class ModelList
    {
        [JsonProperty("list")]
        public List<RootModel> List { get; set; }
        [JsonProperty("city")]
        public CityModel city { get; set; }
    }
}
