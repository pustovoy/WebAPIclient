using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPIclient.Models
{
    public class CityModel
    {
        [JsonProperty("name")]
        public string CityName { get; set; }
    }
}
