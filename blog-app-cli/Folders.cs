using Newtonsoft.Json;

namespace BlogAppCli
{
    public class Folders
    {
        [JsonProperty("client")]
        public string Client { get; set; } = string.Empty;

        [JsonProperty("admin")]
        public string Admin { get; set; } = string.Empty;

        [JsonProperty("api")]
        public string Api { get; set; } = string.Empty;
    }
}
