using Newtonsoft.Json;

namespace DumbnotesCli
{
    public class Script
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        
        [JsonProperty("command")]
        public string Command { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
