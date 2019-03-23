using System;
using Xamarin.Forms;

namespace DepartureBoard
{
    public class Departure
    {
        public int BusLineNumber { get; set; }
        public Color BusLineColor
        {
            get
            {
                switch (this.BusLineNumber)
                {
                    case 3:
                        return Color.Green;
                    case 676:
                        return Color.SlateGray;
                    case 674:
                        return Color.DarkGray;
                    default:
                        return Color.Pink;
                }
            }
        }
        public DateTime DepartureTime { get; set; }
        public string StationName { get; set; }
    }
}