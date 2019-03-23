using Newtonsoft.Json;
namespace DepartureBoard
{
    public class Stationboard
    {
        [JsonProperty("stop")]
        public Stop Stop { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }

    }
}