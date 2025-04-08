/*Task 4: Class & Object 
Create a Following classes with the following attributes and methods: 
1. Event Class: 
• Attributes: 
o event_name, 
o event_date DATE, 
o event_time TIME, 
o venue_name, 
o total_seats, 
o available_seats, 
o ticket_price DECIMAL, 
o event_type ENUM('Movie', 'Sports', 'Concert') 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter, (print all information of attribute) methods for 
the attributes. 
o calculate_total_revenue(): Calculate and return the total revenue based on the 
number of tickets sold. 
o getBookedNoOfTickets(): return the total booked tickets 
o book_tickets(num_tickets): Book a specified number of tickets for an event. Initially 
available seats are equal to the total seats when tickets are booked available seats 
number should be reduced. 
o cancel_booking(num_tickets): Cancel the booking and update the available seats. 
o display_event_details(): Display event details, including event name, date time seat 
availability. 
2. Venue Class 
• Attributes: 
o venue_name,  
o address 
• Methods and Constuctors: 
o display_venue_details(): Display venue details. 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
3. Customer Class 
• Attributes: 
o customer_name,  
o email,  
o phone_number, 
• Methods and Constuctors: 
o Implement default constructors and overload the constructor with Customer 
attributes, generate getter and setter methods. 
o display_customer_details(): Display customer details. 
4. Booking Class to represent the Tiket booking system. Perform the following operation in main 
method. Note:- Use Event class object for the following operation. 
• Methods and Constuctors: 
o calculate_booking_cost(num_tickets): Calculate and set the total cost of the 
booking. 
o book_tickets(num_tickets): Book a specified number of tickets for an event. 
o cancel_booking(num_tickets): Cancel the booking and update the available seats. 
o getAvailableNoOfTickets(): return the total available tickets 
o getEventDetails(): return event details from the event class 
*/


using System;

namespace TicketBookingSystem
{
    public enum EventType { Movie, Sports, Concert }

    public class Customer
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() { }

        public Customer(string name, string email, string phone)
        {
            CustomerName = name;
            Email = email;
            PhoneNumber = phone;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }
    }

    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(string name, string address)
        {
            VenueName = name;
            Address = address;
        }

        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue Name: {VenueName}");
            Console.WriteLine($"Address: {Address}");
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public EventType EventType { get; set; }

        public Event() { }

        public Event(string eventName, DateTime date, TimeSpan time, string venue, int totalSeats, decimal ticketPrice, EventType type)
        {
            EventName = eventName;
            EventDate = date;
            EventTime = time;
            VenueName = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = type;
        }

        public int GetBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        public void BookTickets(int numTickets)
        {
            if (numTickets <= AvailableSeats)
            {
                AvailableSeats -= numTickets;
                Console.WriteLine($"{numTickets} tickets booked successfully.");
            }
            else
            {
                Console.WriteLine("Not enough seats available!");
            }
        }

        public void CancelBooking(int numTickets)
        {
            if (numTickets <= (TotalSeats - AvailableSeats))
            {
                AvailableSeats += numTickets;
                Console.WriteLine($"{numTickets} tickets canceled.");
            }
            else
            {
                Console.WriteLine("You cannot cancel more tickets than have been booked.");
            }
        }

        public decimal CalculateTotalRevenue()
        {
            return GetBookedNoOfTickets() * TicketPrice;
        }

        public void DisplayEventDetails()
        {
            Console.WriteLine($"\nEvent: {EventName}");
            Console.WriteLine($"Date: {EventDate.ToShortDateString()}");
            Console.WriteLine($"Time: {EventTime}");
            Console.WriteLine($"Venue: {VenueName}");
            Console.WriteLine($"Event Type: {EventType}");
            Console.WriteLine($"Ticket Price: Rs.{TicketPrice}");
            Console.WriteLine($"Total Seats: {TotalSeats}, Available Seats: {AvailableSeats}");
        }
    }

    public class Booking
    {
        public Event EventDetails { get; set; }
        public int TicketsBooked { get; private set; }
        public decimal TotalCost { get; private set; }

        public Booking(Event ev)
        {
            EventDetails = ev;
        }

        public void CalculateBookingCost(int numTickets)
        {
            TotalCost = numTickets * EventDetails.TicketPrice;
        }

        public void BookTickets(int numTickets)
        {
            if (numTickets <= EventDetails.AvailableSeats)
            {
                EventDetails.BookTickets(numTickets);
                TicketsBooked += numTickets;
                CalculateBookingCost(numTickets);
                Console.WriteLine($"Total Booking Cost: Rs.{TotalCost}");
            }
            else
            {
                Console.WriteLine("Booking failed. Not enough seats.");
            }
        }

        public void CancelBooking(int numTickets)
        {
            if (numTickets <= TicketsBooked)
            {
                EventDetails.CancelBooking(numTickets);
                TicketsBooked -= numTickets;
                TotalCost -= numTickets * EventDetails.TicketPrice;
                Console.WriteLine("Booking canceled successfully.");
            }
            else
            {
                Console.WriteLine("Cancellation failed. Not enough tickets booked.");
            }
        }

        public int GetAvailableNoOfTickets()
        {
            return EventDetails.AvailableSeats;
        }

        public void GetEventDetails()
        {
            EventDetails.DisplayEventDetails();
        }
    }

    class Program
    {
        static void Main()
        {
            Event ev = new Event("Music", DateTime.Parse("2025-05-01"), new TimeSpan(18, 30, 0), "City Arena", 100, 500.00m, EventType.Concert);
            Customer cust = new Customer("Anjali", "anjali@egmail.com", "9897511123");
            Venue venue = new Venue("City Arena", "MG Road, Delhi");

            Booking booking = new Booking(ev);

            cust.DisplayCustomerDetails();
            venue.DisplayVenueDetails();
            booking.GetEventDetails();

            booking.BookTickets(3);
            booking.CancelBooking(1);

            Console.WriteLine($"Total Revenue: Rs.{ev.CalculateTotalRevenue()}");
        }
    }
}
