using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartureBoard
{
    class ApiDataConnector : IDataConnector
    {
        private IEnumerable<Departure> _departures;

        public async Task<IEnumerable<Departure>> GetDepartures()
        {
            //Task getRosenberg = GetDeparturesAsync(8581701, 5);
            //Task getSchuetzenhaus = GetDeparturesAsync(8573694, 5);
            //await Task.WhenAll(getRosenberg, getSchuetzenhaus);
            Responseobject responseRosenberg = await GetDeparturesAsync(8581701, 5);
            Responseobject responseSchuetzenhaus = await GetDeparturesAsync(8573694, 5);

            IList<Departure> departuresRosenberg = new List<Departure>();
            foreach(Stationboard e in responseRosenberg.Stationboard)
            {
                if ((e.To == "Winterthur, Museumstrasse/HB") || (e.To == "Winterthur, Oberseen") || (e.To == "Pfungen, Bahnhof"))
                departuresRosenberg.Add(new Departure()
                {
                    BusLineNumber = e.Number,
                    DepartureTime = e.Stop.Departure,
                    StationName = e.Stop.Station.Name
                });
            }

            IList<Departure> departuresSchuetzenhaus = new List<Departure>();
            foreach (Stationboard e in responseSchuetzenhaus.Stationboard)
            {
                if ((e.To == "Winterthur, Museumstrasse/HB") || (e.To == "Winterthur, Oberseen") || (e.To == "Pfungen, Bahnhof"))
                    departuresSchuetzenhaus.Add(new Departure()
                {
                    BusLineNumber = e.Number,
                    DepartureTime = e.Stop.Departure,
                    StationName = e.Stop.Station.Name
                });
            }

            _departures = departuresRosenberg.Union(departuresSchuetzenhaus).OrderBy(f => f.DepartureTime).Take(5);
            return _departures;
        }

        private async Task<Responseobject> GetDeparturesAsync(int stationId, int resultLimit)
        {
            var client = new RestClient("http://transport.opendata.ch");
            var request = new RestRequest($"v1/stationboard?station={stationId}&limit={resultLimit}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = await client.GetAsync<Responseobject>(request);
            return response;
        }
    }
}
