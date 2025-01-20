using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment
{
    class Airlines
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Flight> Flights { get; set; }

        public Airlines(string code, string name)
        {
            Code = code;
            Name = name;
            Flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }
    }
}
