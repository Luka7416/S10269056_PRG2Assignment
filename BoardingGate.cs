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
   
    public class BoardingGate
    {
        public string GateName { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight AssignedFlight { get; set; } // Reference to assigned flight

        public BoardingGate(string gateName, bool supportsDDJB, bool supportsCFFT, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsDDJB = supportsDDJB;
            SupportsCFFT = supportsCFFT;
            SupportsLWTT = supportsLWTT;
            AssignedFlight = null; // Initially unassigned
        }
    }


}
