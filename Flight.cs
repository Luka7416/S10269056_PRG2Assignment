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
        public string FlightNumber { get; set; }
        public Airline Airline { get; set; } // Direct reference to Airline
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public BoardingGate BoardingGate { get; set; } // Direct reference to BoardingGate

        protected Flight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
        {
            FlightNumber = flightNumber;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            BoardingGate = null; // Initially unassigned
        }

        public abstract int CalculateFee();
    }
}
