using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number	: S10269056F
// Student Name	: THINN MYAT MYAT HTWE
// Partner Name	: EI EI KHIN
//==========================================================
namespace S10269056_PRG2Assignment
{
    public class Airline
    {
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public List<Flight> Flights { get; set; } // List of flights belonging to this airline

        public Airline(string airlineCode, string airlineName)
        {
            AirlineCode = airlineCode;
            AirlineName = airlineName;
            Flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }
    }

}
