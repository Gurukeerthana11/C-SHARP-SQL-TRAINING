/*Task9: Exception Handling throw the exception whenever needed and Handle in main method, 1. EventNotFoundException throw this exception when user try to book the tickets for Event not listed in the menu. 2. InvalidBookingIDException throw this exception when user entered the invalid bookingId when he tries to view the booking or cancel the booking. 
 * 3. NullPointerException handle in main method. Throw these exceptions from the methods in TicketBookingSystem class. Make necessary changes to accommodate exception in the source code. Handle all these exceptions from the main program.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace question1
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException(string message) : base(message) { }
    }

    public class InvalidBookingIDException : Exception
    {
        public InvalidBookingIDException(string message) : base(message) { }
    }

    public interface IEventService
    {
        Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue);
        List<Event> GetEventDetails();
        int GetAvailableNoOfTickets();
    }

    public interface IBookingService
    {
        decimal CalculateBookingCost(int numTickets, decimal ticketPrice);
        Booking BookTickets(string eventName, int numTickets, Customer[] customers);
        bool CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }

    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }
        public Venue(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }

        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
        }
    }

    public abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public Event() { }

        public Event(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue)
        {
            EventName = name;
            EventDate = date;
            EventTime = time;
            TotalSeats = seats;
            AvailableSeats = seats;
            TicketPrice = price;
            EventType = type;
            Venue = venue;
        }

        public abstract void DisplayEventDetails();

        public int GetBookedNoOfTickets() => TotalSeats - AvailableSeats;

        public bool BookTickets(int num)
        {
            if (AvailableSeats >= num)
            {
                AvailableSeats -= num;
                return true;
            }
            return false;
        }

        public void CancelBooking(int num)
        {
            AvailableSeats += num;
        }

        public decimal CalculateTotalRevenue() => TicketPrice * (TotalSeats - AvailableSeats);
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string genre, string actor, string actress)
            : base(name, date, time, seats, price, type, venue)
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string artist, string concertType)
            : base(name, date, time, seats, price, type, venue)
        {
            Artist = artist;
            Type = concertType;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {Type}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
        }
    }

    public class Sport : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sport(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string sportName, string teams)
            : base(name, date, time, seats, price, type, venue)
        {
            SportName = sportName;
            TeamsName = teams;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Sport: {EventName}, Game: {SportName}, Teams: {TeamsName}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() { }
        public Customer(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {PhoneNumber}");
        }
    }

    public class Booking
    {
        private static int BookingCounter = 1;
        public int BookingId { get; set; }
        public Customer[] Customers { get; set; }
        public Event Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        public Booking(Event ev, int numTickets, Customer[] customers)
        {
            BookingId = BookingCounter++;
            Event = ev;
            NumTickets = numTickets;
            Customers = customers;
            TotalCost = ev.TicketPrice * numTickets;
            BookingDate = DateTime.Now;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}, Event: {Event.EventName}, Tickets: {NumTickets}, Total: Rs.{TotalCost}, Date: {BookingDate}");
            foreach (var c in Customers)
                c.DisplayCustomerDetails();
        }
    }

    public class EventManager : IEventService
    {
        protected List<Event> events = new List<Event>();

        public Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue)
        {
            Event ev = null;
            if (eventType.ToLower() == "movie")
                ev = new Movie(eventName, date, time, totalSeats, ticketPrice, eventType, venue, "Action", "Actor", "Actress");
            else if (eventType.ToLower() == "concert")
                ev = new Concert(eventName, date, time, totalSeats, ticketPrice, eventType, venue, "Artist", "Rock");
            else if (eventType.ToLower() == "sport")
                ev = new Sport(eventName, date, time, totalSeats, ticketPrice, eventType, venue, "Cricket", "India vs Pakistan");

            if (ev != null) events.Add(ev);
            return ev;
        }

        public List<Event> GetEventDetails() => events;

        public int GetAvailableNoOfTickets() => events.Sum(e => e.AvailableSeats);
    }

    public class BookingSystem : EventManager, IBookingService
    {
        private List<Booking> bookings = new List<Booking>();

        public decimal CalculateBookingCost(int numTickets, decimal ticketPrice) => numTickets * ticketPrice;

        public Booking BookTickets(string eventName, int numTickets, Customer[] customers)
        {
            Event ev = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (ev == null)
                throw new EventNotFoundException("Event not found: " + eventName);

            if (!ev.BookTickets(numTickets))
                throw new Exception("Not enough seats available.");

            Booking b = new Booking(ev, numTickets, customers);
            bookings.Add(b);
            return b;
        }

        public bool CancelBooking(int bookingId)
        {
            Booking b = bookings.Find(x => x.BookingId == bookingId);
            if (b == null)
                throw new InvalidBookingIDException("Invalid Booking ID: " + bookingId);

            b.Event.CancelBooking(b.NumTickets);
            bookings.Remove(b);
            return true;
        }

        public Booking GetBookingDetails(int bookingId)
        {
            Booking b = bookings.Find(x => x.BookingId == bookingId);
            if (b == null)
                throw new InvalidBookingIDException("Invalid Booking ID: " + bookingId);
            return b;
        }
    }

    class TicketBookingSystem
    {
        static void Main(string[] args)
        {
            IBookingService bookingSystem = new BookingSystem();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nOptions: create_event, book_tickets, cancel_tickets, get_available_seats, get_event_details, exit");
                    Console.Write("Enter command: ");
                    string cmd = Console.ReadLine();

                    if (cmd == "create_event")
                    {
                        Console.Write("Event Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Time (hh:mm): ");
                        TimeSpan time = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Total Seats: ");
                        int seats = int.Parse(Console.ReadLine());
                        Console.Write("Ticket Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Type (Movie/Sport/Concert): ");
                        string type = Console.ReadLine();
                        Console.Write("Venue Name: ");
                        string vname = Console.ReadLine();
                        Console.Write("Venue Address: ");
                        string vaddr = Console.ReadLine();

                        Venue venue = new Venue(vname, vaddr);
                        bookingSystem.CreateEvent(name, date, time, seats, price, type, venue);
                        Console.WriteLine("Event created successfully.");
                    }
                    else if (cmd == "book_tickets")
                    {
                        Console.Write("Event Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Number of Tickets: ");
                        int n = int.Parse(Console.ReadLine());

                        Customer[] custs = new Customer[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Customer {i + 1} Name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Phone: ");
                            string phone = Console.ReadLine();
                            custs[i] = new Customer(cname, email, phone);
                        }

                        Booking b = bookingSystem.BookTickets(name, n, custs);
                        b.DisplayBookingDetails();
                    }
                    else if (cmd == "cancel_tickets")
                    {
                        Console.Write("Booking ID: ");
                        int id = int.Parse(Console.ReadLine());
                        bookingSystem.CancelBooking(id);
                        Console.WriteLine("Booking cancelled.");
                    }
                    else if (cmd == "get_available_seats")
                    {
                        Console.WriteLine("Available Seats: " + bookingSystem.GetAvailableNoOfTickets());
                    }
                    else if (cmd == "get_event_details")
                    {
                        foreach (var e in bookingSystem.GetEventDetails())
                            e.DisplayEventDetails();
                    }
                    else if (cmd == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}

