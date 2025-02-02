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
    public class Airline
    {
        // Properties
        public string Name { get; set; } // Airline name
        public string Code { get; set; } // Airline code
        public Dictionary<string, Flight> Flights { get; set; } // Flights operated by this airline
        public Terminal Terminal { get; set; } // Association with the terminal

        // Constructor
        public Airline(string code, string name)
        {
            Code = code;
            Name = name;
            Flights = new Dictionary<string, Flight>();
        }

        // Add a flight to the airline
        public bool AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights[flight.FlightNumber] = flight;
                flight.Airline = this; // Establish association with the flight
                return true; // Successfully added
            }
            return false; // Flight already exists
        }

        // Remove a flight from the airline
        public bool RemoveFlight(Flight flight)
        {
            if (Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Remove(flight.FlightNumber);
                flight.Airline = null; // Break association with the flight
                return true; // Successfully removed
            }
            return false; // Flight does not exist
        }

        // Calculate the total fees for all flights
        public double CalculateFees()
        {
            double totalFees = 0;
            foreach (var flight in Flights.Values)
            {
                totalFees += flight.CalculateFees(); // Sum up fees from all flights
            }
            return totalFees;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}