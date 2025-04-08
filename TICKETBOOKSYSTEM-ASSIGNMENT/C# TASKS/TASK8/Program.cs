/*Task 8: Interface/abstract class, and Single Inheritance, static variable 
1. Create Venue, class as mentioned above Task 4. 
2. Event Class: 
• Attributes: 
o event_name, 
o event_date DATE, 
o event_time TIME, 
o 
venue (reference of class Venu), 
o total_seats, 
o available_seats, 
o ticket_price DECIMAL, 
o event_type ENUM('Movie', 'Sports', 'Concert') 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter,  (print all information of attribute) methods 
for the attributes. 
3. Create Event sub classes as mentioned in above Task 4. 
4. Create a class Customer and Booking as mentioned in above Task 4. 
5. Create interface/abstract class IEventServiceProvider with following methods: 
• create_event(event_name: str, date:str, time:str, total_seats: int, ticket_price: float, 
event_type: str, venu: Venu): Create a new event with the specified details and event type 
(movie, sport or concert) and return event object. 
• getEventDetails(): return array of event details from the event class. 
• getAvailableNoOfTickets(): return the total available tickets. 
6. Create interface/abstract class IBookingSystemServiceProvider with following methods: 
• calculate_booking_cost(num_tickets): Calculate and set the total cost of the booking. 
• book_tickets(eventname:str, num_tickets, arrayOfCustomer): Book a specified number of 
t
 ickets for an event. for each tickets customer object should be created and stored in array 
also should update the attributes of Booking class. 
• cancel_booking(booking_id): Cancel the booking and update the available seats. 
• get_booking_details(booking_id):get the booking details. 
7. Create EventServiceProviderImpl class which implements IEventServiceProvider provide all 
implementation methods. 
8. Create BookingSystemServiceProviderImpl class which implements IBookingSystemServiceProvider 
provide all implementation methods and inherits EventServiceProviderImpl class with following 
attributes. 
• Attributes 
o array of events 
9. Create TicketBookingSystem class and perform following operations: 
• Create a simple user interface in a main method that allows users to interact with the ticket 
booking system by entering commands such as "create_event", "book_tickets", 
"cancel_tickets", "get_available_seats,", "get_event_details," and "exit." 
10. Place the interface/abstract class in service package and interface/abstract class implementation 
class, all concrete class in bean package and TicketBookingSystem class in app package. 
11. Should display appropriate message when the event or booking id is not found or any other wrong 
information provided.*/

using System;
using System.Collections.Generic;
using System.Linq;
using question1.bean;

namespace question1.service
{
    public interface IEventServiceProvider
    {
        Event CreateEvent(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, string event_type, Venue venue);
        List<Event> GetEventDetails();
        int GetAvailableNoOfTickets();
    }

    public interface IBookingSystemServiceProvider
    {
        decimal CalculateBookingCost(int num_tickets, decimal ticket_price);
        Booking BookTickets(string eventname, int num_tickets, Customer[] customers);
        bool CancelBooking(int booking_id);
        Booking GetBookingDetails(int booking_id);
    }
}

namespace question1.bean
{
    using question1.service;

    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }
        public Venue(string name, string address) => (VenueName, Address) = (name, address);

        public void DisplayVenueDetails() => Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
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
        public bool BookTickets(int n) { if (AvailableSeats >= n) { AvailableSeats -= n; return true; } return false; }
        public void CancelBooking(int n) => AvailableSeats += n;
        public decimal CalculateTotalRevenue() => TicketPrice * (TotalSeats - AvailableSeats);
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string genre, string actor, string actress)
            : base(name, date, time, seats, price, type, venue) => (Genre, ActorName, ActressName) = (genre, actor, actress);

        public override void DisplayEventDetails() => Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string ConcertType { get; set; }

        public Concert(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string artist, string concertType)
            : base(name, date, time, seats, price, type, venue) => (Artist, ConcertType) = (artist, concertType);

        public override void DisplayEventDetails() => Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {ConcertType}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
    }

    public class Sport : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sport(string name, DateTime date, TimeSpan time, int seats, decimal price, string type, Venue venue, string sportName, string teams)
            : base(name, date, time, seats, price, type, venue) => (SportName, TeamsName) = (sportName, teams);

        public override void DisplayEventDetails() => Console.WriteLine($"Sport: {EventName}, Game: {SportName}, Teams: {TeamsName}, Venue: {Venue.VenueName}, Seats Left: {AvailableSeats}");
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() { }
        public Customer(string name, string email, string phone) => (Name, Email, PhoneNumber) = (name, email, phone);
        public void DisplayCustomerDetails() => Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {PhoneNumber}");
    }

    public class Booking
    {
        public static int BookingCounter = 1;
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

        public void DisplayBookingDetails() => Console.WriteLine($"Booking ID: {BookingId}, Event: {Event.EventName}, Tickets: {NumTickets}, Total: Rs.{TotalCost}, Date: {BookingDate}");
    }

    public class EventServiceProviderImpl : IEventServiceProvider
    {
        protected List<Event> events = new List<Event>();

        public Event CreateEvent(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, string event_type, Venue venue)
        {
            Event ev = event_type.ToLower() switch
            {
                "movie" => new Movie(event_name, date, time, total_seats, ticket_price, event_type, venue, "Action", "Actor", "Actress"),
                "concert" => new Concert(event_name, date, time, total_seats, ticket_price, event_type, venue, "Artist", "Rock"),
                "sport" => new Sport(event_name, date, time, total_seats, ticket_price, event_type, venue, "Cricket", "India vs Pakistan"),
                _ => null
            };

            if (ev != null) events.Add(ev);
            return ev;
        }

        public List<Event> GetEventDetails() => events;
        public int GetAvailableNoOfTickets() => events.Sum(e => e.AvailableSeats);
    }

    public class BookingSystemServiceProviderImpl : EventServiceProviderImpl, IBookingSystemServiceProvider
    {
        private List<Booking> bookings = new List<Booking>();

        public decimal CalculateBookingCost(int num_tickets, decimal ticket_price) => num_tickets * ticket_price;

        public Booking BookTickets(string eventname, int num_tickets, Customer[] customers)
        {
            Event ev = events.Find(e => e.EventName.Equals(eventname, StringComparison.OrdinalIgnoreCase));
            if (ev != null && ev.BookTickets(num_tickets))
            {
                Booking b = new Booking(ev, num_tickets, customers);
                bookings.Add(b);
                return b;
            }
            return null;
        }

        public bool CancelBooking(int booking_id)
        {
            Booking b = bookings.Find(x => x.BookingId == booking_id);
            if (b != null)
            {
                b.Event.CancelBooking(b.NumTickets);
                bookings.Remove(b);
                return true;
            }
            return false;
        }

        public Booking GetBookingDetails(int booking_id) => bookings.Find(x => x.BookingId == booking_id);
    }
}

namespace question1.app
{
    using question1.bean;

    class TicketBookingSystem
    {
        static void Main(string[] args)
        {
            var system = new BookingSystemServiceProviderImpl();

            while (true)
            {
                Console.WriteLine("\nOptions: create_event, book_tickets, cancel_tickets, get_available_seats, get_event_details, exit");
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();

                if (cmd == "create_event")
                {
                    Console.Write("Event Name: "); string name = Console.ReadLine();
                    Console.Write("Date (yyyy-mm-dd): "); DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Time (hh:mm): "); TimeSpan time = TimeSpan.Parse(Console.ReadLine());
                    Console.Write("Total Seats: "); int seats = int.Parse(Console.ReadLine());
                    Console.Write("Ticket Price: "); decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Type (Movie/Sport/Concert): "); string type = Console.ReadLine();
                    Console.Write("Venue Name: "); string vname = Console.ReadLine();
                    Console.Write("Venue Address: "); string vaddr = Console.ReadLine();

                    Venue venue = new Venue(vname, vaddr);
                    system.CreateEvent(name, date, time, seats, price, type, venue);
                    Console.WriteLine("Event created successfully.");
                }
                else if (cmd == "book_tickets")
                {
                    Console.Write("Event Name: "); string name = Console.ReadLine();
                    Console.Write("Number of Tickets: "); int n = int.Parse(Console.ReadLine());

                    Customer[] customers = new Customer[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Customer {i + 1} Name: "); string cname = Console.ReadLine();
                        Console.Write("Email: "); string email = Console.ReadLine();
                        Console.Write("Phone: "); string phone = Console.ReadLine();
                        customers[i] = new Customer(cname, email, phone);
                    }

                    Booking b = system.BookTickets(name, n, customers);
                    if (b != null) b.DisplayBookingDetails();
                    else Console.WriteLine("Booking failed.");
                }
                else if (cmd == "cancel_tickets")
                {
                    Console.Write("Booking ID: "); int id = int.Parse(Console.ReadLine());
                    if (system.CancelBooking(id)) Console.WriteLine("Booking cancelled.");
                    else Console.WriteLine("Booking ID not found.");
                }
                else if (cmd == "get_available_seats")
                {
                    Console.WriteLine("Available Seats: " + system.GetAvailableNoOfTickets());
                }
                else if (cmd == "get_event_details")
                {
                    foreach (var e in system.GetEventDetails()) e.DisplayEventDetails();
                }
                else if (cmd == "exit") break;
                else Console.WriteLine("Invalid command.");
            }
        }
    }
}
