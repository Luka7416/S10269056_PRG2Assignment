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
    public class Terminal
    {
        public string Name { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, Flight> Flights { get; set; } // Changed from List<Flight> to Dictionary<string, Flight>

        public Terminal(string name)
        {
            Name = name;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
        }

        public void AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.AirlineCode))
                Airlines[airline.AirlineCode] = airline;
        }

        public void AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
                BoardingGates[gate.GateName] = gate;
        }

        public void AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights[flight.FlightNumber] = flight;
                flight.Airline?.AddFlight(flight); // Associate the flight with the airline
            }
            else
            {
                Console.WriteLine($"Flight {flight.FlightNumber} already exists and cannot be added again.");
            }
        }
    }
}

