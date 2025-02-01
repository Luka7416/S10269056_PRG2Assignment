﻿using System;
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
    public class LWTTFlight : Flight
    {
        public double RequestFee { get; set; }

        public LWTTFlight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
            : base(flightNumber, origin, destination, expectedTime, status, airline)
        {
            RequestFee = 500; // Specific request fee for LWTT flights
        }

        public override double CalculateFees()
        {
            double fee = 300; // Base fee for all flights
            if (Destination == "Singapore (SIN)") fee += 500;
            if (Origin == "Singapore (SIN)") fee += 800;
            fee += RequestFee; // Additional fee for LWTT
            return fee;
        }

        public override string ToString()
        {
            return base.ToString() + $", Request Fee: {RequestFee} (LWTT Flight)";
        }
    }
}
