using Newtonsoft.Json;
using System.Collections.Generic;

namespace DepartureBoard
{
    public class Responseobject
    {
        //[JsonProperty("station")]
        //public Station Station {get; set;}
        [JsonProperty("stationboard")]
        public List<Stationboard> Stationboard { get; set; }
    }
}
