//2. Use conditional statements (if-else) to determine if the ticket is available or not.

namespace question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter available tickets : ");
            int availableticket = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter No of tickets : ");
            int no_of_bookings = Convert.ToInt32(Console.ReadLine());
            if(availableticket >= no_of_bookings)
                Console.Write("The ticket is available");
            else
                Console.Write("The ticket is not available");
        }
    }
}
