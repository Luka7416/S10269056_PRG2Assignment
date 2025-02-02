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
    public class Terminal
    {
        // Properties
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, double> GateFees { get; set; } // Association for gate fees

        // Constructor
        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
            GateFees = new Dictionary<string, double>();
        }

        // Add an airline to the terminal
        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines[airline.Code] = airline;
                airline.Terminal = this; // Establish association with the airline
                return true; // Successfully added
            }
            return false; // Airline already exists
        }

        // Add a boarding gate to the terminal
        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates[gate.GateName] = gate;
                return true; // Successfully added
            }
            return false; // Boarding gate already exists
        }

        // Add a flight to the terminal
        public void AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights[flight.FlightNumber] = flight;
                if (flight.Airline != null && Airlines.ContainsKey(flight.Airline.Code))
                {
                    flight.Airline.AddFlight(flight); // Associate flight with its airline
                }
            }
        }

        // Get an airline from a flight
        public Airline GetAirlineFromFlight(string flightNumber)
        {
            return Flights.ContainsKey(flightNumber) ? Flights[flightNumber].Airline : null;
        }

        // Print airline fees
        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine($"Airline: {airline.Name}, Fees: {airline.CalculateFees()}");
            }
        }

        // ToString override
        public override string ToString()
        {
            return $"Terminal Name: {TerminalName}, Airlines: {Airlines.Count}, Boarding Gates: {BoardingGates.Count}, Flights: {Flights.Count}";
        }
    }
}
