
using S10269056_PRG2Assignment;


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
{
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
        terminal.AddBoardingGate(new BoardingGate(parts[0].Trim(),
            bool.Parse(parts[1]), bool.Parse(parts[2]), bool.Parse(parts[3]))); // Gate Name, DDJB, CFFT, LWTT
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