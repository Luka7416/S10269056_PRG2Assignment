using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment
{
    abstract class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public Airlines Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public BoardingGate BoardingGate { get; set; }

        protected Flight(string flightNumber, Airline airline, string origin, string destination, string time, string status = "On Time")
        {
            FlightNumber = flightNumber;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            Time = DateTime.ParseExact(time, "HH:mm", null);
            Status = status;
        }

        public int CompareTo(Flight other)
        {
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"Flight {FlightNumber} ({Airline.Name}): {Origin} -> {Destination}, Time: {Time:hh:mm tt}, Status: {Status}, Gate: {BoardingGate?.Code ?? "None"}";
        }
    }
}
