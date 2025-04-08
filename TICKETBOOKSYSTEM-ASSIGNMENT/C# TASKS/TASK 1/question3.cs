namespace question3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter available tickets : ");
            int availableticket = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter No of tickets : ");
            int no_of_bookings = Convert.ToInt32(Console.ReadLine());
            if (availableticket >= no_of_bookings)
            {
                
                Console.Write("The ticket is available");
            }
            else
                Console.Write($"The ticket is not available.{no_of_bookings-availableticket} tickets are more from available tickets" );
        }
    }
}
