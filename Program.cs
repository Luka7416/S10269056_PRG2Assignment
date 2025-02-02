﻿
//•	THINN MYAT MYAT HTWE will implement features 2, 3, 5, 6 & 9, and EI EI KHIN will implement features 1, 4, 7 & 8.  

using S10269056_PRG2Assignment;
using System.Collections.Generic;


//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================


// Create a terminal for the flight system
Terminal terminal = new Terminal("Changi Airport Terminal 5");

// Initialize data from CSV files

InitializeData();
Console.WriteLine("Loading Airlines...");
Console.WriteLine($"{terminal.Airlines.Count} Airlines Loaded!");
Console.WriteLine("Loading Boarding Gates...");
Console.WriteLine($"{terminal.BoardingGates.Count} Boarding Gates Loaded!");
Console.WriteLine("Loading Flights...");
Console.WriteLine($"{terminal.Flights.Count} Flights Loaded!\n");

void InitializeData()
{   //(1)	Load files (airlines and boarding gates)
    // Load airlines
    var airlineLines = File.ReadAllLines("airlines.csv");
    foreach (var line in airlineLines.Skip(1)) // Skip the header row
    {
        var parts = line.Split(',');
        terminal.AddAirline(new Airline(parts[1].Trim(), parts[0].Trim())); // Airline Code, Airline Name
    }

    // Load boarding gates
    var gateLines = File.ReadAllLines("boardinggates.csv");
    foreach (var line in gateLines.Skip(1)) // Skip the header row
    {
        var parts = line.Split(',');

        // Parse the values correctly
        string gateName = parts[0].Trim();
        bool supportsDDJB = bool.Parse(parts[1].Trim());
        bool supportsCFFT = bool.Parse(parts[2].Trim());
        bool supportsLWTT = bool.Parse(parts[3].Trim());

        // Add the boarding gate to the terminal
        terminal.AddBoardingGate(new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT, terminal));
    }

    //==========================================================
    // Student Number	: S10269056F
    // Student Name	: THINN MYAT MYAT HTWE
    // Partner Name	: EI EI KHIN
    //==========================================================

    //load flights
    var flightLines = File.ReadAllLines("flights.csv");
    foreach (var line in flightLines.Skip(1)) // Skip the header row
    {
        var parts = line.Split(',');
        string flightNumber = parts[0].Trim();
        string origin = parts[1].Trim();
        string destination = parts[2].Trim();
        DateTime expectedTime = DateTime.Parse(parts[3].Trim());
        string specialRequest = parts.Length > 4 && !string.IsNullOrWhiteSpace(parts[4]) ? parts[4].Trim() : "NORM";

        // Find the airline for the flight
        string airlineCode = flightNumber.Split(' ')[0];
        Airline airline = terminal.Airlines.ContainsKey(airlineCode) ? terminal.Airlines[airlineCode] : null;

        // Create flight object based on special request
        Flight flight = specialRequest switch
        {
            "DDJB" => new DDJBFlight(flightNumber, airline, origin, destination, expectedTime),
            "CFFT" => new CFFTFlight(flightNumber, airline, origin, destination, expectedTime),
            "LWTT" => new LWTTFlight(flightNumber, airline, origin, destination, expectedTime),
            _ => new NORMFlight(flightNumber, airline, origin, destination, expectedTime)
        };

        terminal.AddFlight(flight);
    }

}
//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================

// Function to display the main menu
void DisplayMenu()
{
    int choice;
    do
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine("Welcome to Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        Console.WriteLine("1. List All Flights");
        Console.WriteLine("2. List Boarding Gates");
        Console.WriteLine("3. Assign a Boarding Gate to a Flight");
        Console.WriteLine("4. Create Flight");
        Console.WriteLine("5. Display Airline Flights");
        Console.WriteLine("6. Modify Flight Details");
        Console.WriteLine("7. Display Flight Schedule");
        Console.WriteLine("8. Process Unassigned Flights in Bulk");
        Console.WriteLine("9. Display Total Fees Per Airline");
        Console.WriteLine("0. Exit");
        Console.Write("Please select your option: ");
        choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ListAllFlights();
                break;
            case 2:
                ListBoardingGates();
                break;
            case 3:
                AssignBoardingGate();
                break;
            case 4:
                CreateFlight();

                break;
            case 5:
                DisplayFlightsByAirline();
                break;
            case 6:
                ModifyFlightDetails();
                break;
            case 7:
                DisplayFlightSchedule();
                break;
            case 8:
                ProcessUnassignedFlightsInBulk();
                break;
            case 9:
                DisplayTotalFeesPerAirline();
                break;

            case 0:
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    } while (choice != 0);
}


//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================

//(4)	List all boarding gates

void ListBoardingGates()
{
    Console.WriteLine("\n=============================================");
    Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Gate Name",-15} {"DDJB",-20} {"CFFT",-20} {"LWTT",-20}");

    foreach (var gate in terminal.BoardingGates.Values)
    {
        Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-20} {gate.SupportsCFFT,-20} {gate.SupportsLWTT,-20}");
    }
}


//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================

//(7)	Display full flight details from an airline

// Function to display flights by airline
void DisplayFlightsByAirline()
{
    Console.WriteLine("\n=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Airline Code",-15} {"Airline Name"}");

    // Display all airlines
    foreach (var airlineentry in terminal.Airlines.Values)
    {
        Console.WriteLine($"{airlineentry.Code,-15} {airlineentry.Name}");
    }

    Console.Write("\nEnter Airline Code: ");
    string airlineCode = Console.ReadLine()?.Trim().ToUpper();

    // Validate airline code
    if (!terminal.Airlines.TryGetValue(airlineCode, out var airline))
    {
        Console.WriteLine("\nInvalid Airline Code.");
        return;
    }

    Console.WriteLine($"\n=============================================");
    Console.WriteLine($"List of Flights for {airline.Name}");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Flight Number",-15} {"Airline Name",-25} {"Origin",-25} {"Destination",-25} {"Expected Departure/Arrival Time"}");

    // Retrieve and display flights for the selected airline
    var flights = terminal.Flights.Values
        .Where(f => f.Airline == airline)
        .OrderBy(f => f.ExpectedTime);

    foreach (var flight in flights)
    {
        Console.WriteLine($"{flight.FlightNumber,-15} {airline.Name,-25} {flight.Origin,-25} {flight.Destination,-25} {flight.ExpectedTime:dd/MM/yyyy h:mm:00 tt}");
    }

    // Handle the case where no flights are found
    if (!flights.Any())
    {
        Console.WriteLine("No flights available for this airline.");
    }
}

//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================

//(8)	Modify flight details
void ModifyFlightDetails()
{
    Console.WriteLine("\n=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Airline Code",-15} {"Airline Name"}");

    // Display all airlines
    foreach (var airlineentry in terminal.Airlines.Values)
    {
        Console.WriteLine($"{airlineentry.Code,-15} {airlineentry.Name}");
    }

    Console.Write("\nEnter Airline Code: ");
    string airlineCode = Console.ReadLine()?.Trim().ToUpper();

    // Validate airline code
    if (!terminal.Airlines.TryGetValue(airlineCode, out var airline))
    {
        Console.WriteLine("\nInvalid Airline Code.");
        return;
    }

    Console.WriteLine($"\nList of Flights for {airline.Name}");
    Console.WriteLine($"{"Flight Number",-15} {"Airline Name",-25} {"Origin",-25} {"Destination",-25} {"Expected Departure/Arrival Time"}");

    // Retrieve and display flights for the selected airline
    var flights = terminal.Flights.Values
        .Where(f => f.Airline == airline)
        .OrderBy(f => f.ExpectedTime);

    foreach (var flight in flights)
    {
        Console.WriteLine($"{flight.FlightNumber,-15} {airline.Name,-25} {flight.Origin,-25} {flight.Destination,-25} {flight.ExpectedTime:dd/MM/yyyy h:mm:00 tt}");
    }

    if (!flights.Any())
    {
        Console.WriteLine("\nNo flights available for this airline.");
        return;
    }

    Console.Write("\nChoose an existing Flight to modify or delete: ");
    string flightNumber = Console.ReadLine()?.Trim().ToUpper();

    // Validate flight number
    if (!terminal.Flights.TryGetValue(flightNumber, out var selectedFlight))
    {
        Console.WriteLine("\nFlight not found.");
        return;
    }

    Console.WriteLine("\n1. Modify Flight");
    Console.WriteLine("2. Delete Flight");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("\n1. Modify Basic Information");
        Console.WriteLine("2. Modify Status");
        Console.WriteLine("3. Modify Special Request Code");
        Console.WriteLine("4. Modify Boarding Gate");
        Console.Write("Choose an option: ");
        string modifyChoice = Console.ReadLine();

        switch (modifyChoice)
        {
            case "1": // Modify Basic Information
                Console.Write("Enter new Origin: ");
                string newOrigin = Console.ReadLine();
                Console.Write("Enter new Destination: ");
                string newDestination = Console.ReadLine();
                Console.Write("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy H:mm", null, System.Globalization.DateTimeStyles.None, out var newTime))
                {
                    selectedFlight.Origin = newOrigin;
                    selectedFlight.Destination = newDestination;
                    selectedFlight.ExpectedTime = newTime;
                    Console.WriteLine("\nFlight updated!");

                    // Display updated flight details
                    Console.WriteLine($"Flight Number: {selectedFlight.FlightNumber}");
                    Console.WriteLine($"Airline Name: {selectedFlight.Airline.Name}");
                    Console.WriteLine($"Origin: {selectedFlight.Origin}");
                    Console.WriteLine($"Destination: {selectedFlight.Destination}");
                    Console.WriteLine($"Expected Departure/Arrival Time: {selectedFlight.ExpectedTime:dd/MM/yyyy h:mm:00 tt}");
                    Console.WriteLine($"Status: {selectedFlight.Status}");
                    Console.WriteLine($"Special Request Code: {selectedFlight.SpecialRequestCode}");
                    Console.WriteLine($"Boarding Gate: {selectedFlight.BoardingGate?.GateName ?? "Unassigned"}");
                }
                else
                {
                    Console.WriteLine("\nInvalid date/time format.");
                    return;
                }
                break;

            case "2": // Modify Status
                Console.WriteLine("\n1. Scheduled");
                Console.WriteLine("2. Boarding");
                Console.WriteLine("3. Delayed");
                Console.Write("Choose a new status: ");
                string statusChoice = Console.ReadLine();

                selectedFlight.Status = statusChoice switch
                {
                    "1" => "Scheduled",
                    "2" => "Boarding",
                    "3" => "Delayed",
                    _ => selectedFlight.Status
                };
                Console.WriteLine("\nFlight status updated!");
                break;

            case "3": // Modify Special Request Code
                Console.Write("Enter new Special Request Code (NORM, DDJB, CFFT, LWTT): ");
                selectedFlight.SpecialRequestCode = Console.ReadLine()?.Trim().ToUpper();
                Console.WriteLine("\nSpecial request code updated!");
                break;


            case "4": // Modify Boarding Gate
                Console.Write("Enter new Boarding Gate: ");
                string newGate = Console.ReadLine();
                if (terminal.BoardingGates.ContainsKey(newGate))
                {
                    selectedFlight.BoardingGate = terminal.BoardingGates[newGate];
                    Console.WriteLine("\nBoarding gate updated!");
                }
                else
                {
                    Console.WriteLine("\nInvalid boarding gate.");
                }
                break;

            default:
                Console.WriteLine("\nInvalid option.");
                break;
        }
    }
    else if (choice == "2")
    {
        // Delete flight
        Console.Write("Are you sure you want to delete this flight? (Y/N): ");
        string confirm = Console.ReadLine()?.Trim().ToUpper();
        if (confirm == "Y")
        {
            terminal.Flights.Remove(selectedFlight.FlightNumber);
            Console.WriteLine("\nFlight deleted successfully.");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid option.");
    }
}


//==========================================================
// Student Number	: S10269738E
// Student Name	: EI EI KHIN
// Partner Name	: THINN MYAT MYAT HTWE
//==========================================================
//(a)	Process all unassigned flights to boarding gates in bulk

void ProcessUnassignedFlightsInBulk()
{
    Console.WriteLine("\n=============================================");
    Console.WriteLine("Processing Unassigned Flights in Bulk");
    Console.WriteLine("=============================================");

    Queue<Flight> unassignedFlights = new Queue<Flight>();
    List<BoardingGate> availableGates = terminal.BoardingGates.Values
        .Where(gate => gate.Flight == null)
        .ToList();

    // Identify unassigned flights
    foreach (var flight in terminal.Flights.Values)
    {
        if (flight.BoardingGate == null)
        {
            unassignedFlights.Enqueue(flight);
        }
    }

    int initiallyUnassignedFlights = unassignedFlights.Count;
    int initiallyUnassignedGates = availableGates.Count;

    Console.WriteLine($"Total Unassigned Flights: {initiallyUnassignedFlights}");
    Console.WriteLine($"Total Unassigned Boarding Gates: {initiallyUnassignedGates}");

    int assignedCount = 0;

    // Process the queue of unassigned flights
    while (unassignedFlights.Count > 0 && availableGates.Count > 0)
    {
        Flight flight = unassignedFlights.Dequeue();
        BoardingGate selectedGate = null;

        // Find a suitable gate
        if (!string.IsNullOrEmpty(flight.SpecialRequestCode) && flight.SpecialRequestCode != "None")
        {
            // Look for a matching gate for special requests
            selectedGate = availableGates.FirstOrDefault(gate =>
                (flight is DDJBFlight && gate.SupportsDDJB) ||
                (flight is CFFTFlight && gate.SupportsCFFT) ||
                (flight is LWTTFlight && gate.SupportsLWTT));
        }
        else
        {
            // Look for a general unassigned gate for normal flights
            selectedGate = availableGates.FirstOrDefault();
        }

        // Assign the flight to the selected gate
        if (selectedGate != null)
        {
            selectedGate.AssignFlight(flight);
            availableGates.Remove(selectedGate); // Remove assigned gate from available list
            assignedCount++;

            // Display assigned flight details
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"Flight Number: {flight.FlightNumber}");
            Console.WriteLine($"Airline Name: {flight.Airline.Name}");
            Console.WriteLine($"Origin: {flight.Origin}");
            Console.WriteLine($"Destination: {flight.Destination}");
            Console.WriteLine($"Expected Time: {flight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}");
            Console.WriteLine($"Special Request Code: {(string.IsNullOrEmpty(flight.SpecialRequestCode) ? "None" : flight.SpecialRequestCode)}");
            Console.WriteLine($"Assigned Boarding Gate: {selectedGate.GateName}");
        }
    }

    //Display Summary
    Console.WriteLine("\n=============================================");
    Console.WriteLine($"Total Flights Processed: {initiallyUnassignedFlights}");
    Console.WriteLine($"Total Gates Processed: {initiallyUnassignedGates}");
    Console.WriteLine($"Total Flights Assigned: {assignedCount}");
    Console.WriteLine($"Auto-Assignment Percentage: {(initiallyUnassignedFlights > 0 ? ((double)assignedCount / initiallyUnassignedFlights) * 100 : 0):F2}%");
}