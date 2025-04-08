/*Task 2: Nested Conditional Statements 
Create a program that simulates a Ticket booking and calculating cost of tickets. Display tickets options 
such as "Silver", "Gold", "Dimond". Based on ticket category fix the base ticket price and get the user input 
for ticket type and no of tickets need and calculate the total cost of tickets booked.*/

namespace question1
{
   

    class TicketBooking
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Ticket Booking System");
            Console.WriteLine("Available Ticket Categories:");
            Console.WriteLine("1. Silver");
            Console.WriteLine("2. Gold");
            Console.WriteLine("3. Diamond");

            Console.Write("Enter your ticket category (Silver/Gold/Diamond): ");
            string ticketType = Console.ReadLine();

            Console.Write("Enter number of tickets: ");
            int numberOfTickets= Convert.ToInt32(Console.ReadLine());
            int pricePerTicket = 0;

            if (ticketType == "silver")
            {
                pricePerTicket = 100;
            }
            else if (ticketType == "gold")
            {
                pricePerTicket = 200;
            }
            else if (ticketType == "diamond")
            {
                pricePerTicket = 300;
            }
            else
            {
                Console.WriteLine("Invalid ticket category selected.");
                return;
            }

            int totalCost = pricePerTicket * numberOfTickets;

            Console.WriteLine("\nBooking Summary:");
            Console.WriteLine($"Ticket Type: {ticketType.ToUpper()}");
            Console.WriteLine($"Number of Tickets: {numberOfTickets}");
            Console.WriteLine($"Price per Ticket: Rs.{pricePerTicket}");
            Console.WriteLine($"Total Cost: Rs.{totalCost}");
        }
    }

}
