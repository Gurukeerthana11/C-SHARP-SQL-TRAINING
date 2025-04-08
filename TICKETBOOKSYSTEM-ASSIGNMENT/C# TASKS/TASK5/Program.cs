
/*Task 5: Inheritance and polymorphism 
1. Inheritance 
• Create a subclass Movie that inherits from Event. Add the following attributes and methods: 
o Attributes: 
1. genre: Genre of the movie (e.g., Action, Comedy, Horror). 
2. ActorName 
3. ActresName 
o Methods: 
1. Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
2. display_event_details(): Display movie details, including genre. 
• Create another subclass Concert that inherits from Event. Add the following attributes and 
methods: 
o Attributes: 
1. artist: Name of the performing artist or band. 
2. type: (Theatrical, Classical, Rock, Recital) 
o Methods: 
1. Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
2. display_concert_details(): Display concert details, including the artist. 
• Create another subclass Sports that inherits from Event. Add the following attributes and 
methods: 
Task 6: Abstraction 
Requirements: 
1. sportName: Name of the game. 
2. teamsName: (India vs Pakistan) 
o Methods: 
1. Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
2. display_sport_details(): Display concert details, including the artist. 
• Create a class TicketBookingSystem with the following methods:  
o create_event(event_name: str, date:str, time:str, total_seats: int, ticket_price: 
f
 loat, event_type: str, venu_name:str): Create a new event with the specified details 
and event type (movie, sport or concert) and return event object.  
o display_event_details(event: Event): Accepts an event object and calls its 
display_event_details() method to display event details. 
o book_tickets(event: Event, num_tickets: int):  
1. Accepts an event object and the number of tickets to be booked. 
2. Checks if there are enough available seats for the booking. 
3. If seats are available, updates the available seats and returns the total cost 
of the booking. 
4. If seats are not available, displays a message indicating that the event is sold 
out. 
o cancel_tickets(event: Event, num_tickets): cancel a specified number of tickets for 
an event. 
o main(): simulates the ticket booking system 
1. User can book tickets and view the event details as per their choice in menu 
(movies, sports, concerts). 
2. Display event details using the display_event_details() method without 
knowing the specific event type (demonstrate polymorphism). 
3. Make bookings using the book_tickets() and cancel tickets cancel_tickets() 
method. */


using System;

namespace Question1
{
    public abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public Event() { }

        public Event(string eventName, DateTime eventDate, TimeSpan eventTime,
                     string venueName, int totalSeats, decimal ticketPrice)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            VenueName = venueName;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
        }

        public abstract void DisplayEventDetails();
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie() { }

        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime,
                     string venueName, int totalSeats, decimal ticketPrice,
                     string genre, string actor, string actress)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Movie Details ---");
            Console.WriteLine($"Name: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()} Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}, Price: Rs.{TicketPrice}, Available Seats: {AvailableSeats}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert() { }

        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime,
                       string venueName, int totalSeats, decimal ticketPrice,
                       string artist, string type)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Artist = artist;
            Type = type;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Concert Details ---");
            Console.WriteLine($"Name: {EventName}, Artist: {Artist}, Type: {Type}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()} Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}, Price: Rs.{TicketPrice}, Available Seats: {AvailableSeats}");
        }
    }

    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports() { }

        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime,
                      string venueName, int totalSeats, decimal ticketPrice,
                      string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Sports Details ---");
            Console.WriteLine($"Match: {TeamsName}, Sport: {SportName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()} Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}, Price: Rs.{TicketPrice}, Available Seats: {AvailableSeats}");
        }
    }

    public class TicketBookingSystem
    {
        public Event CreateEvent()
        {
            Console.Write("Enter Event Type (movie/concert/sports): ");
            string eventType = Console.ReadLine().ToLower();

            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Event Time (hh:mm): ");
            TimeSpan time = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Enter Venue Name: ");
            string venue = Console.ReadLine();
            Console.Write("Enter Total Seats: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter Ticket Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            if (eventType == "movie")
            {
                Console.Write("Enter Genre: ");
                string genre = Console.ReadLine();
                Console.Write("Enter Actor Name: ");
                string actor = Console.ReadLine();
                Console.Write("Enter Actress Name: ");
                string actress = Console.ReadLine();
                return new Movie(name, date, time, venue, seats, price, genre, actor, actress);
            }
            else if (eventType == "concert")
            {
                Console.Write("Enter Artist Name: ");
                string artist = Console.ReadLine();
                Console.Write("Enter Type (Rock/Classical/Theatrical): ");
                string type = Console.ReadLine();
                return new Concert(name, date, time, venue, seats, price, artist, type);
            }
            else if (eventType == "sports")
            {
                Console.Write("Enter Sport Name: ");
                string sport = Console.ReadLine();
                Console.Write("Enter Teams (e.g., India vs Pakistan): ");
                string teams = Console.ReadLine();
                return new Sports(name, date, time, venue, seats, price, sport, teams);
            }

            Console.WriteLine("Invalid Event Type.");
            return null;
        }

        public void BookTickets(Event ev)
        {
            Console.Write("Enter number of tickets to book: ");
            int num = int.Parse(Console.ReadLine());

            if (num <= ev.AvailableSeats)
            {
                ev.AvailableSeats -= num;
                Console.WriteLine($"Booking successful! Total Cost: Rs.{ev.TicketPrice * num}");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public void CancelTickets(Event ev)
        {
            Console.Write("Enter number of tickets to cancel: ");
            int num = int.Parse(Console.ReadLine());
            ev.AvailableSeats += num;
            Console.WriteLine("Cancellation successful.");
        }

        public void Run()
        {
            Console.WriteLine("--- Welcome to the Ticket Booking System ---");

            Event myEvent = CreateEvent();
            if (myEvent == null) return;

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. View Event Details");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        myEvent.DisplayEventDetails();
                        break;
                    case 2:
                        BookTickets(myEvent);
                        break;
                    case 3:
                        CancelTickets(myEvent);
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the system!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            new TicketBookingSystem().Run();
        }
    }
}
