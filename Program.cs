/*
* Project Name:Hotel Management System
* Author Name:Mehrfam Rabieyan
* Date:9/10/23
* Application Purpose:Assessment2- Programming1
*/


using System;
using System.Collections.Generic;

 

class Program
{
    static List<Room> rooms = new List<Room>();



    static void Main(string[] args)
    {
        InitializeRooms();



        while (true)
        {
            Console.Clear();
            Console.WriteLine("CITYLIGHT Resorts - Room Reservation System");
            Console.WriteLine("1. View Available Rooms");
            Console.WriteLine("2. Make Reservation");
            Console.WriteLine("3. Cancel Reservation");
            Console.WriteLine("4. View Occupied Rooms");
            Console.WriteLine("5. Calculate Total Revenue");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");



            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewAvailableRooms();
                        break;
                    case 2:
                        MakeReservation();
                        break;
                    case 3:
                        CancelReservation();
                        break;
                    case 4:
                        ViewOccupiedRooms();
                        break;
                    case 5:
                        CalculateTotalRevenue();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }



            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }



    static void InitializeRooms()
    {
        rooms.Add(new Room("101", "Single", 100));
        rooms.Add(new Room("102", "Double", 150));
        rooms.Add(new Room("103", "Suite", 200));
    }



    static void ViewAvailableRooms()
    {
        Console.Clear();
        Console.WriteLine("Available Rooms:");
        Console.WriteLine("---------------");



        foreach (var room in rooms)
        {
            if (!room.IsOccupied)
            {
                Console.WriteLine($"Room {room.Number} - {room.Type} - ${room.Price} per night");
            }
        }
    }



    static void MakeReservation()
    {
        Console.Clear();
        Console.WriteLine("Make a Reservation:");
        Console.WriteLine("-------------------");



        ViewAvailableRooms();



        Console.Write("Enter room number to reserve: ");
        string roomNumber = Console.ReadLine();



        var room = rooms.Find(r => r.Number == roomNumber);



        if (room != null && !room.IsOccupied)
        {
            Console.Write("Enter guest name: ");
            string guestName = Console.ReadLine();



            room.Reserve(guestName);
            Console.WriteLine($"Reservation for {guestName} in Room {room.Number} confirmed.");
        }
        else
        {
            Console.WriteLine("Invalid room number or room is already occupied.");
        }
    }



    static void CancelReservation()
    {
        Console.Clear();
        Console.WriteLine("Cancel Reservation:");
        Console.WriteLine("------------------");



        Console.Write("Enter room number to cancel reservation: ");
        string roomNumber = Console.ReadLine();



        var room = rooms.Find(r => r.Number == roomNumber);



        if (room != null && room.IsOccupied)
        {
            Console.WriteLine($"Reservation for {room.GuestName} in Room {room.Number} has been canceled.");
            room.CancelReservation();
        }
        else
        {
            Console.WriteLine("Invalid room number or room is not occupied.");
        }
    }



    static void ViewOccupiedRooms()
    {
        Console.Clear();
        Console.WriteLine("Occupied Rooms:");
        Console.WriteLine("---------------");



        foreach (var room in rooms)
        {
            if (room.IsOccupied)
            {
                Console.WriteLine($"Room {room.Number} - {room.GuestName}");
            }
        }
    }



    static void CalculateTotalRevenue()
    {
        Console.Clear();
        Console.WriteLine("Calculate Total Revenue:");
        Console.WriteLine("------------------------");



        double totalRevenue = 0;



        foreach (var room in rooms)
        {
            if (room.IsOccupied)
            {
                totalRevenue += room.Price;
            }
        }



        Console.WriteLine($"Total Revenue: ${totalRevenue}");
    }
}



class Room
{
    public string Number { get; }
    public string Type { get; }
    public double Price { get; }
    public string GuestName { get; private set; }
    public bool IsOccupied { get { return !string.IsNullOrEmpty(GuestName); } }



    public Room(string number, string type, double price)
    {
        Number = number;
        Type = type;
        Price = price;
    }



    public void Reserve(string guestName)
    {
        GuestName = guestName;
    }



    public void CancelReservation()
    {
        GuestName = string.Empty;
    }
}
