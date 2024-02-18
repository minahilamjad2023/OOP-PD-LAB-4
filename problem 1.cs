using System;
using System.Collections.Generic;

class Angle
{
    public int degrees;
    public float minutes;
    public char direction;

    
    public Angle(int degrees, float minutes, char direction)
    {
        this.degrees = degrees;
        this.minutes = minutes;
        this.direction = direction;
    }

   
    public void ChangeAngle(int degrees, float minutes, char direction)
    {
        this.degrees = degrees;
        this.minutes = minutes;
        this.direction = direction;
    }

   
    public string DisplayAngle() // for the angle conversion as provided in the problem
    {
        return $"{degrees}\u00b0{minutes}' {direction}"; 
    }
}

class Ship
{
    public string shipNumber;
    public Angle latitude;
    public Angle longitude;

    // Parameterized constructor for the Ship class
    public Ship(string shipNumber, int latDegrees, float latMinutes, char latDirection, int lonDegrees, float lonMinutes, char lonDirection)
    {
        this.shipNumber = shipNumber;
        this.latitude = new Angle(latDegrees, latMinutes, latDirection);
        this.longitude = new Angle(lonDegrees, lonMinutes, lonDirection);
    }

    // Member function to print the position (latitude and longitude) of the ship
    public void PrintPosition()
    {
        Console.WriteLine($"Ship Position: Latitude - {latitude.DisplayAngle()}, Longitude - {longitude.DisplayAngle()}");
    }

    
    public void PrintSerialNumber()
    {
        Console.WriteLine($"Ship Serial Number: {shipNumber}");
    }

   
    public string GetShipNumber()
    {
        return shipNumber;
    }

    
    public void ChangePosition(int latDegrees, float latMinutes, char latDirection, int lonDegrees, float lonMinutes, char lonDirection)
    {
        latitude.ChangeAngle(latDegrees, latMinutes, latDirection);
        longitude.ChangeAngle(lonDegrees, lonMinutes, lonDirection);
    }
}

class Program
{
    static void Main()
    {
        List<Ship> ships = new List<Ship>();

        while (true)
        {
            Console.WriteLine("Driver Program Menu:");
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddShip(ships);
                    break;
                case 2:
                    ViewShipPosition(ships);
                    break;
                case 3:
                    ViewShipSerialNumber(ships);
                    break;
                case 4:
                    ChangeShipPosition(ships);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void AddShip(List<Ship> ships)
    {
        Console.Write("Enter Ship Number: ");
        string shipNumber = Console.ReadLine();

        Console.WriteLine("Enter Ship Latitude:");
        Console.Write("Enter Latitude’s Degree: ");
        int latDegrees = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Latitude’s Minute: ");
        float latMinutes = Convert.ToSingle(Console.ReadLine());
        Console.Write("Enter Latitude’s Direction: ");
        char latDirection = Convert.ToChar(Console.ReadLine());

        Console.WriteLine("Enter Ship Longitude:");
        Console.Write("Enter Longitude’s Degree: ");
        int lonDegrees = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Longitude’s Minute: ");
        float lonMinutes = Convert.ToSingle(Console.ReadLine());
        Console.Write("Enter Longitude’s Direction: ");
        char lonDirection = Convert.ToChar(Console.ReadLine());

        Ship newShip = new Ship(shipNumber, latDegrees, latMinutes, latDirection, lonDegrees, lonMinutes, lonDirection);
        ships.Add(newShip);

        Console.WriteLine("Ship added successfully!\n");
    }

    static void ViewShipPosition(List<Ship> ships)
    {
        Console.Write("Enter Ship Serial Number to find its position: ");
        string serialNumber = Console.ReadLine();

        Ship ship = FindShipBySerialNumber(ships, serialNumber);

        if (ship != null)
        {
            ship.PrintPosition();
        }
        else
        {
            Console.WriteLine("Ship not found with the given serial number.\n");
        }
    }

    static void ViewShipSerialNumber(List<Ship> ships)
    {
        Console.Write("Enter the ship latitude: ");
        string latitude = Console.ReadLine();
        Console.Write("Enter the ship longitude: ");
        string longitude = Console.ReadLine();

        Ship ship = FindShipByPosition(ships, latitude, longitude);

        if (ship != null)
        {
            ship.PrintSerialNumber();
        }
        else
        {
            Console.WriteLine("Ship not found with the given position.\n");
        }
    }

    static void ChangeShipPosition(List<Ship> ships)
    {
        Console.Write("Enter Ship’s serial number whose position you want to change: ");
        string serialNumber = Console.ReadLine();

        Ship ship = FindShipBySerialNumber(ships, serialNumber);

        if (ship != null)
        {
            Console.WriteLine("Enter Ship Latitude:");
            Console.Write("Enter Latitude’s Degree: ");
            int latDegrees = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Latitude’s Minute: ");
            float latMinutes = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter Latitude’s Direction: ");
            char latDirection = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude:");
            Console.Write("Enter Longitude’s Degree: ");
            int lonDegrees = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Longitude’s Minute: ");
            float lonMinutes = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter Longitude’s Direction: ");
            char lonDirection = Convert.ToChar(Console.ReadLine());

            ship.ChangePosition(latDegrees, latMinutes, latDirection, lonDegrees, lonMinutes, lonDirection);
            Console.WriteLine("Ship position changed successfully!\n");
        }
        else
        {
            Console.WriteLine("Ship not found with the given serial number.\n");
        }
    }

    static Ship FindShipBySerialNumber(List<Ship> ships, string serialNumber) // using list 
    {
        foreach (Ship ship in ships)
        {
            if (ship.GetShipNumber() == serialNumber)
            {
                return ship;
            }
        }
        return null;
    }

    static Ship FindShipByPosition(List<Ship> ships, string latitude, string longitude)
    {
        foreach (Ship ship in ships)
        {
            if (ship.latitude.DisplayAngle() == latitude && ship.longitude.DisplayAngle() == longitude)
            {
                return ship;
            }
        }
        return null;
    }
}

