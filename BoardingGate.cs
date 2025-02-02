using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S10269056_PRG2Assignment;

//==========================================================
// Student Number	: S10269056F
// Student Name	: THINN MYAT MYAT HTWE
// Partner Name	: EI EI KHIN
//==========================================================
namespace PRG2_Assignment
{
    public class BoardingGate
    {
        // Properties
        public string GateName { get; set; } // Name of the gate
        public bool SupportsCFFT { get; set; } // Indicates if the gate supports CFFT flights
        public bool SupportsDDJB { get; set; } // Indicates if the gate supports DDJB flights
        public bool SupportsLWTT { get; set; } // Indicates if the gate supports LWTT flights
        public Flight Flight { get; private set; } // Associated flight (nullable)
        public Terminal Terminal { get; set; } // Associated terminal

        // Constructor
        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT, Terminal terminal)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            Terminal = terminal;
            Flight = null; // Initially, no flight is assigned
        }

        // Assign a flight to this gate
        public bool AssignFlight(Flight flight)
        {
            if (Flight == null) // Ensure the gate is available
            {
                // Allow all normal flights (NORMFlight)
                if (flight is NORMFlight ||
                    (flight is DDJBFlight && SupportsDDJB) ||
                    (flight is CFFTFlight && SupportsCFFT) ||
                    (flight is LWTTFlight && SupportsLWTT))
                {
                    Flight = flight;
                    flight.BoardingGate = this;
                    return true;
                }
            }

            return false;
        }


        // Remove the assigned flight
        public void RemoveFlight()
        {
            Flight = null;
        }

        // Override ToString method
        public override string ToString()
        {
            string flightDetails = Flight != null ? Flight.ToString() : "No flight assigned";
            return $"Gate: {GateName}, Supports CFFT: {SupportsCFFT}, Supports DDJB: {SupportsDDJB}, Supports LWTT: {SupportsLWTT}, Assigned Flight: {flightDetails}";
        }
    }
}