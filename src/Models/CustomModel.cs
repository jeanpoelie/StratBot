using Newtonsoft.Json;

namespace StratBot.Models
{
    public class CustomModel
    {

        [JsonProperty("timePlayed")]
        public int? timePlayed { get; set; }
    }
}
