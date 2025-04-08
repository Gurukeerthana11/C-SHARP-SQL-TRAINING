/*Task 7: Has A Relation / Association 
Create a Following classes with the following attributes and methods: 
1. Venue Class 
• Attributes: 
o venue_name,  
o address 
• Methods and Constuctors: 
o display_venue_details(): Display venue details. 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
2. Event Class: 
• Attributes: 
o event_name, 
o event_date DATE, 
o event_time TIME, 
o venue (reference of class Venu), 
o total_seats, 
o available_seats, 
o ticket_price DECIMAL, 
o event_type ENUM('Movie', 'Sports', 'Concert') 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter,  (print all information of attribute) methods 
for the attributes. 
o calculate_total_revenue(): Calculate and return the total revenue based on the 
number of tickets sold. 
o getBookedNoOfTickets(): return the total booked tickets 
o book_tickets(num_tickets): Book a specified number of tickets for an event. Initially 
available seats are equal to total seats when tickets are booked available seats 
number should be reduced. 
o cancel_booking(num_tickets): Cancel the booking and update the available seats. 
o display_event_details(): Display event details, including event name, date time seat 
availability. 
3. Event sub classes: 
• Create three sub classes that inherit from Event abstract class and override abstract 
methods in concrete class should declare the variables as mentioned in above Task 2: 
o Movie. 
o Concert. 
o Sport. 
4. Customer Class 
• Attributes: 
o customer_name,  
o email,  
o phone_number, 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
o display_customer_details(): Display customer details. 
5. Create a class Booking with the following attributes: 
• bookingId (should be incremented for each booking) 
• array of customer (reference to the customer who made the booking) 
• event (reference to the event booked) 
• num_tickets(no of tickets and array of customer must equal) 
• total_cost 
• booking_date (timestamp of when the booking was made) 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
o display_booking_details(): Display customer details. 
6. BookingSystem Class to represent the Ticket booking system. Perform the following operation in 
main method. Note: - Use Event class object for the following operation. 
• Attributes 
o array of events 
• Methods and Constuctors: 
o create_event(event_name: str, date:str, time:str, total_seats: int, ticket_price: 
f
 loat, event_type: str, venu:Venu): Create a new event with the specified details and 
event type (movie, sport or concert) and return event object.  
o calculate_booking_cost(num_tickets): Calculate and set the total cost of the 
booking. 
o book_tickets(eventname:str, num_tickets, arrayOfCustomer): Book a specified 
number of tickets for an event. for each tickets customer object should be created 
and stored in array also should update the attributes of Booking class. 
o cancel_booking(booking_id): Cancel the booking and update the available seats. 
o getAvailableNoOfTickets(): return the total available tickets 
o getEventDetails(): return event details from the event class 
o Create a simple user interface in a main method that allows users to interact with 
the ticket booking system by entering commands such as "create_event", 
"book_tickets", "cancel_tickets", "get_available_seats,", "get_event_details," and 
"exit."*/


using System;
using System.Collections.Generic;

namespace question1
{
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

        public Event(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }

        public virtual void DisplayEventDetails()
        {
            Console.WriteLine($"Event: {EventName} ({EventType}), Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Price: Rs.{TicketPrice}, Available Seats: {AvailableSeats}");
            Venue.DisplayVenueDetails();
        }

        public void BookTickets(int numTickets)
        {
            if (AvailableSeats >= numTickets)
                AvailableSeats -= numTickets;
            else
                Console.WriteLine("Not enough seats available.");
        }

        public void CancelBooking(int numTickets)
        {
            AvailableSeats += numTickets;
        }

        public int GetBookedTickets() => TotalSeats - AvailableSeats;

        public decimal CalculateTotalRevenue() => GetBookedTickets() * TicketPrice;
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie() { }

        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        public override void DisplayEventDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert() { }

        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            Type = type;
        }

        public override void DisplayEventDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Artist: {Artist}, Type: {Type}");
        }
    }

    public class Sport : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sport() { }

        public Sport(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sport")
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public override void DisplayEventDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Sport: {SportName}, Teams: {TeamsName}");
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
        private static int bookingCounter = 1000;
        public int BookingId { get; }
        public Customer[] Customers { get; set; }
        public Event Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        public Booking() { BookingId = bookingCounter++; }

        public Booking(Customer[] customers, Event evt, int numTickets)
        {
            BookingId = bookingCounter++;
            Customers = customers;
            Event = evt;
            NumTickets = numTickets;
            TotalCost = evt.TicketPrice * numTickets;
            BookingDate = DateTime.Now;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"\nBooking ID: {BookingId}, Date: {BookingDate}, Total Cost: Rs.{TotalCost}");
            Event.DisplayEventDetails();
            Console.WriteLine("Booked Customers:");
            foreach (var customer in Customers)
                customer.DisplayCustomerDetails();
        }
    }

    public class BookingSystem
    {
        List<Event> events = new List<Event>();
        List<Booking> bookings = new List<Booking>();

        public Event CreateEvent(string type)
        {
            Console.Write("Enter event name: ");
            string name = Console.ReadLine();
            Console.Write("Enter date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter time (HH:mm): ");
            TimeSpan time = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Enter total seats: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter ticket price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter venue name: ");
            string vName = Console.ReadLine();
            Console.Write("Enter venue address: ");
            string vAddr = Console.ReadLine();

            Venue venue = new Venue(vName, vAddr);

            Event ev = null;
            if (type == "movie")
            {
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();
                Console.Write("Enter actor name: ");
                string actor = Console.ReadLine();
                Console.Write("Enter actress name: ");
                string actress = Console.ReadLine();
                ev = new Movie(name, date, time, venue, seats, price, genre, actor, actress);
            }
            else if (type == "concert")
            {
                Console.Write("Enter artist: ");
                string artist = Console.ReadLine();
                Console.Write("Enter concert type: ");
                string ctype = Console.ReadLine();
                ev = new Concert(name, date, time, venue, seats, price, artist, ctype);
            }
            else if (type == "sport")
            {
                Console.Write("Enter sport name: ");
                string sport = Console.ReadLine();
                Console.Write("Enter teams (e.g. India vs Pakistan): ");
                string teams = Console.ReadLine();
                ev = new Sport(name, date, time, venue, seats, price, sport, teams);
            }

            if (ev != null) events.Add(ev);
            return ev;
        }

        public void BookTickets(string eventName, int numTickets)
        {
            Event ev = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (ev == null || ev.AvailableSeats < numTickets)
            {
                Console.WriteLine("Event not found or not enough seats.");
                return;
            }

            Customer[] customers = new Customer[numTickets];
            for (int i = 0; i < numTickets; i++)
            {
                Console.WriteLine($"Enter details for ticket {i + 1}");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Phone: ");
                string phone = Console.ReadLine();
                customers[i] = new Customer(name, email, phone);
            }

            ev.BookTickets(numTickets);
            Booking booking = new Booking(customers, ev, numTickets);
            bookings.Add(booking);
            booking.DisplayBookingDetails();
        }

        public void CancelBooking(int bookingId)
        {
            Booking booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            booking.Event.CancelBooking(booking.NumTickets);
            bookings.Remove(booking);
            Console.WriteLine($"Booking {bookingId} cancelled successfully.");
        }

        public void ShowAvailableSeats(string eventName)
        {
            Event ev = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(ev != null ? $"Available Seats: {ev.AvailableSeats}" : "Event not found.");
        }

        public void ShowEventDetails()
        {
            foreach (var ev in events)
            {
                ev.DisplayEventDetails();
                Console.WriteLine("----------------------");
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nCommands: create_event, book_tickets, cancel_tickets, get_available_seats, get_event_details, exit");
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine().ToLower();

                switch (cmd)
                {
                    case "create_event":
                        Console.Write("Enter type (movie/concert/sport): ");
                        CreateEvent(Console.ReadLine().ToLower());
                        break;
                    case "book_tickets":
                        Console.Write("Enter event name: ");
                        string ename = Console.ReadLine();
                        Console.Write("Enter number of tickets: ");
                        int num = int.Parse(Console.ReadLine());
                        BookTickets(ename, num);
                        break;
                    case "cancel_tickets":
                        Console.Write("Enter booking ID: ");
                        CancelBooking(int.Parse(Console.ReadLine()));
                        break;
                    case "get_available_seats":
                        Console.Write("Enter event name: ");
                        ShowAvailableSeats(Console.ReadLine());
                        break;
                    case "get_event_details":
                        ShowEventDetails();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookingSystem bookingSystem = new BookingSystem();
            bookingSystem.Run();
        }
    }
}
