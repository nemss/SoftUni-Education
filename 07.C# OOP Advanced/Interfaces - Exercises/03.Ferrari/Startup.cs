namespace _03.Ferrari
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var driverName = Console.ReadLine();

            var car = new Models.Ferrari(driverName);

            Console.WriteLine(car);
        }
    }
}