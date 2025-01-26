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
    public class NORMFlight : Flight
    {
        public NORMFlight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
            : base(flightNumber, airline, origin, destination, expectedTime, status)
        {
        }

        public override int CalculateFee()
        {
            int fee = 300; // Base fee for all flights
            if (Destination == "Singapore (SIN)") fee += 500; // Arriving flight fee
            if (Origin == "Singapore (SIN)") fee += 800; // Departing flight fee
            return fee;
        }
    }
}
