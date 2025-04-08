/*Task 3: Looping 
From the above task book the tickets for repeatedly until user type "Exit" */

using System;

class TicketBooking
{
    static void Main()
    {
        Console.WriteLine("Welcome to Ticket Booking System");

        while (true)
        {
            Console.WriteLine("\nAvailable Ticket Categories:");
            Console.WriteLine("1. Silver");
            Console.WriteLine("2. Gold");
            Console.WriteLine("3. Diamond");
            Console.WriteLine("Type 'Exit' to stop booking.\n");

            Console.Write("Enter ticket category (Silver/Gold/Diamond/Exit): ");
            string ticketType = Console.ReadLine();

            if (ticketType == "exit")
            {
                Console.WriteLine("Thank you for using the Ticket Booking System!");
                break;
            }

            double pricePerTicket = 0;

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
                Console.WriteLine("Invalid ticket category selected");
                continue;
            }

            Console.Write("Enter number of tickets: ");
            int numberOfTickets;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out numberOfTickets);

            if (!isValidNumber || numberOfTickets <= 0)
            {
                Console.WriteLine("Invalid number of tickets. Please enter a valid number.");
                continue;
            }

            double totalCost = pricePerTicket * numberOfTickets;

            Console.WriteLine("\nBooking Summary:");
            Console.WriteLine($"Ticket Type: {ticketType.ToUpper()}");
            Console.WriteLine($"Number of Tickets: {numberOfTickets}");
            Console.WriteLine($"Price per Ticket: ${pricePerTicket}");
            Console.WriteLine($"Total Cost: ${totalCost}");
        }
    }
}
