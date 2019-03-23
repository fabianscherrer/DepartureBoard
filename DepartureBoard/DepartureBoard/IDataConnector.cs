using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartureBoard
{
    internal interface IDataConnector
    {
        Task<IEnumerable<Departure>> GetDepartures();
    }
}