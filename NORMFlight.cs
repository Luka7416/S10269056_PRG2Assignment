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
            : base(flightNumber, origin, destination, expectedTime, status, airline)
        {
        }

        public override double CalculateFees()
        {
            double fee = 300; // Base fee for all flights
            if (Destination == "Singapore (SIN)") fee += 500;
            if (Origin == "Singapore (SIN)") fee += 800;
            return fee; // No extra request fee for NORM flights
        }

        public override string ToString()
        {
            return base.ToString() + " (Normal Flight)";
        }
    }
}
