namespace _5.DateModifier
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();
            var date = new DateModifier(firstDate, secondDate);
            date.CalculateDifferenceBetweenTwoDates();
        }
    }
}
