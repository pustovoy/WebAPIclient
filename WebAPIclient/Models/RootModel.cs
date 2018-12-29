using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace WebAPIclient.Models
{
    public class RootModel
    {
        private DateTime _forecastDateTime;

        [JsonProperty("dt")]
        public string ForecastDateTime
        {
            get { return _forecastDateTime.ToString(); }
            set
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                _forecastDateTime = dtDateTime.AddSeconds(Convert.ToDouble(value)).ToLocalTime(); ;
            }
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("main")]
        public MainModel Main { get; set; }

        public RootModel()
        {
            Main = new MainModel();
        }
    }
}
