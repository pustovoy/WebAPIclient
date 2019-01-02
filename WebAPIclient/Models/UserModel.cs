using Newtonsoft.Json;

namespace WebAPIclient.Models
{
    public class UserModel
    {
        [JsonProperty("bio")]
        public string Biography { get; set; }
        [JsonProperty("blog")]
        public string Blog { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("hireable")]
        public bool Hireable { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
