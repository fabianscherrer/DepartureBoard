using Newtonsoft.Json;
using System;

namespace DepartureBoard
{
    public class Stop
    {
        [JsonProperty("station")]
        public Station Station { get; set; }
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }
    }
}