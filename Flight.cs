using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================


namespace S10269056_PRG2Assignment
{
    public abstract class Flight
    {
        internal object Airline;

        public string FlightNumber { get; set; }
        public string AirlineCode { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public string BoardingGate { get; set; }

        protected Flight(string flightNumber, string airlineCode, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
        {
            FlightNumber = flightNumber;
            AirlineCode = airlineCode;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            BoardingGate = null; // Initially unassigned
        }

        // Abstract method to calculate fees
        public abstract int CalculateFee();
    }
}
