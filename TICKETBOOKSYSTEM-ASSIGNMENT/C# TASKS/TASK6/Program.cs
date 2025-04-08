/* TASK 6: Event Abstraction: 
• Create an abstract class Event that represents a generic event. It should include the 
following attributes and methods as mentioned in TASK 1: 
2. Concrete Event Classes: 
• Create three concrete classes that inherit from Event abstract class and override abstract 
methods in concrete class should declare the variables as mentioned in above Task 2: 
• Movie. 
• Concert. 
• Sport. 
3. BookingSystem Abstraction: 
• Create an abstract class BookingSystem that represents the ticket booking system. It should 
include the methods of TASK 2 TicketBookingSystem: 
4. Concrete TicketBookingSystem Class: 
www.hexaware.com 
© Hexaware Technologies Limited. All rights 
• Create a concrete class TicketBookingSystem that inherits from BookingSystem: 
• TicketBookingSystem: Implement the abstract methods to create events, book 
t
 ickets, and retrieve available seats. Maintain an array of events in this class. 
• Create a simple user interface in a main method that allows users to interact with the ticket 
booking system by entering commands such as "create_event", "book_tickets", 
"cancel_tickets", "get_available_seats," and "exit." */


using System;
using System.Collections.Generic;

namespace question1
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

        public Event(string name, DateTime date, TimeSpan time, string venue, int seats, decimal price)
        {
            EventName = name;
            EventDate = date;
            EventTime = time;
            VenueName = venue;
            TotalSeats = seats;
            AvailableSeats = seats;
            TicketPrice = price;
        }

        public abstract void DisplayEventDetails();
    }

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie(string name, DateTime date, TimeSpan time, string venue, int seats, decimal price,
                     string genre, string actor, string actress)
            : base(name, date, time, venue, seats, price)
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Movie ---\nTitle: {EventName}\nGenre: {Genre}\nStarring: {ActorName} & {ActressName}\nDate: {EventDate.ToShortDateString()} Time: {EventTime}\nVenue: {VenueName}\nPrice: {TicketPrice:C}\nAvailable Seats: {AvailableSeats}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert(string name, DateTime date, TimeSpan time, string venue, int seats, decimal price,
                       string artist, string type)
            : base(name, date, time, venue, seats, price)
        {
            Artist = artist;
            Type = type;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Concert ---\nTitle: {EventName}\nArtist: {Artist}\nType: {Type}\nDate: {EventDate.ToShortDateString()} Time: {EventTime}\nVenue: {VenueName}\nPrice: {TicketPrice:C}\nAvailable Seats: {AvailableSeats}");
        }
    }

    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports(string name, DateTime date, TimeSpan time, string venue, int seats, decimal price,
                      string sport, string teams)
            : base(name, date, time, venue, seats, price)
        {
            SportName = sport;
            TeamsName = teams;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"\n--- Sports ---\nSport: {SportName}\nMatch: {TeamsName}\nDate: {EventDate.ToShortDateString()} Time: {EventTime}\nVenue: {VenueName}\nPrice:{TicketPrice:C}\nAvailable Seats: {AvailableSeats}");
        }
    }

    public abstract class BookingSystem
    {
        public abstract Event CreateEvent();
        public abstract void DisplayEventDetails(Event ev);
        public abstract void BookTickets(Event ev, int count);
        public abstract void CancelTickets(Event ev, int count);
        public abstract int GetAvailableSeats(Event ev);
    }

    public class TicketBookingSystem : BookingSystem
    {
        private List<Event> events = new List<Event>();

        public override Event CreateEvent()
        {
            Console.Write("Enter event type (movie/concert/sports): ");
            string type = Console.ReadLine().ToLower();

            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Time (hh:mm): ");
            TimeSpan time = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Enter Venue: ");
            string venue = Console.ReadLine();
            Console.Write("Enter Total Seats: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter Ticket Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Event ev = null;

            switch (type)
            {
                case "movie":
                    Console.Write("Enter Genre: ");
                    string genre = Console.ReadLine();
                    Console.Write("Enter Actor Name: ");
                    string actor = Console.ReadLine();
                    Console.Write("Enter Actress Name: ");
                    string actress = Console.ReadLine();
                    ev = new Movie(name, date, time, venue, seats, price, genre, actor, actress);
                    break;

                case "concert":
                    Console.Write("Enter Artist Name: ");
                    string artist = Console.ReadLine();
                    Console.Write("Enter Type (Rock/Classical): ");
                    string concertType = Console.ReadLine();
                    ev = new Concert(name, date, time, venue, seats, price, artist, concertType);
                    break;

                case "sports":
                    Console.Write("Enter Sport Name: ");
                    string sport = Console.ReadLine();
                    Console.Write("Enter Teams (e.g. India vs Pakistan): ");
                    string teams = Console.ReadLine();
                    ev = new Sports(name, date, time, venue, seats, price, sport, teams);
                    break;

                default:
                    Console.WriteLine("Invalid event type.");
                    break;
            }

            if (ev != null)
            {
                events.Add(ev);
                Console.WriteLine("Event created successfully.");
            }

            return ev;
        }

        public override void DisplayEventDetails(Event ev)
        {
            ev.DisplayEventDetails();
        }

        public override void BookTickets(Event ev, int count)
        {
            if (count <= ev.AvailableSeats)
            {
                ev.AvailableSeats -= count;
                Console.WriteLine($"Successfully booked {count} tickets. Total Cost: Rs.{ev.TicketPrice * count}");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public override void CancelTickets(Event ev, int count)
        {
            ev.AvailableSeats += count;
            Console.WriteLine($"{count} tickets cancelled. New available seats: {ev.AvailableSeats}");
        }

        public override int GetAvailableSeats(Event ev)
        {
            return ev.AvailableSeats;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. View Events");
                Console.WriteLine("3. Book Tickets");
                Console.WriteLine("4. Cancel Tickets");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateEvent();
                        break;

                    case "2":
                        for (int i = 0; i < events.Count; i++)
                        {
                            Console.WriteLine($"\nEvent ID: {i}");
                            DisplayEventDetails(events[i]);
                        }
                        break;

                    case "3":
                        Console.Write("Enter Event ID to book: ");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter no. of tickets: ");
                        int num = int.Parse(Console.ReadLine());
                        BookTickets(events[bookId], num);
                        break;

                    case "4":
                        Console.Write("Enter Event ID to cancel: ");
                        int cancelId = int.Parse(Console.ReadLine());
                        Console.Write("Enter no. of tickets to cancel: ");
                        int cancelNum = int.Parse(Console.ReadLine());
                        CancelTickets(events[cancelId], cancelNum);
                        break;

                    case "5":
                        Console.WriteLine("Exiting system.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            TicketBookingSystem system = new TicketBookingSystem();
            system.Run();
        }
    }
}