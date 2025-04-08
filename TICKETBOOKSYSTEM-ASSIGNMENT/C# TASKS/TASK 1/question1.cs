/*task1 :Conditional Statements In a BookingSystem, you have been given the task is to create a program to book tickets. 
if available t ickets more than noOfTicket to book then display the remaining tickets or ticket unavailable: */


namespace question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter available tickets : ");
            int availableticket=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter No of tickets : ");
            int no_of_bookings=Convert.ToInt32(Console.ReadLine());
            //to display
            //Console.WriteLine($"availableticket is {availableticket}\nNo of bookings is {no_of_bookings}");
        }
    }
}
