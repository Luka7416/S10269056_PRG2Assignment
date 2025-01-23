using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10269056_PRG2Assignment
{
    class BoardingGate
    {
        public string Code { get; set; }
        public List<string> SupportedRequests { get; set; }
        public Flight AssignedFlight { get; set; }

        public BoardingGate(string code, List<string> supportedRequests)
        {
            Code = code;
            SupportedRequests = supportedRequests;
            AssignedFlight = null;
        }

        public bool AssignFlight(Flight flight)
        {
            if (AssignedFlight == null)
            {
                AssignedFlight = flight;
                flight.BoardingGate = this;
                return true;
            }
            return false;
        }
    }
}
