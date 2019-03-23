using Newtonsoft.Json;
namespace DepartureBoard
{
    public class Station
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}