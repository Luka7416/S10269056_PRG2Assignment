using System;
using System.Collections.Generic;
using System.Linq;
using PRG2_Assignment;
using System;

//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================

namespace S10269056_PRG2Assignment;

    public abstract class Flight
    {
        // Properties
        public string FlightNumber { get; set; } // Unique flight number
        public string Origin { get; set; } // Origin of the flight
        public string Destination { get; set; } // Destination of the flight
        public DateTime ExpectedTime { get; set; } // Expected departure/arrival time
        public string Status { get; set; } // Status of the flight (e.g., "Scheduled", "Delayed")
        public Airline Airline { get; set; } // Associated airline (0..* to 1 relationship)
        public BoardingGate BoardingGate { get; set; } // Associated boarding gate (nullable)

        // Special Request Code
        public string SpecialRequestCode { get; set; } // Backing field for SpecialRequestCode

        // Constructor
        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, Airline airline)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            Airline = airline ?? throw new ArgumentNullException(nameof(airline)); // Ensure every flight has an airline
            BoardingGate = null; // Initialize as unassigned
            SpecialRequestCode = "None"; // Default value
        }

        // Abstract Method to Calculate Fees
        public abstract double CalculateFees();

        // Override ToString Method
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, Origin: {Origin}, Destination: {Destination}, " +
                   $"Expected: {ExpectedTime}, Status: {Status}, Airline: {Airline?.Name ?? "No airline assigned"}, " +
                   $"Boarding Gate: {BoardingGate?.GateName ?? "Unassigned"}, Special Request Code: {SpecialRequestCode}";
        }
    }


