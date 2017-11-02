using System;

namespace _3.GenericCountMethod
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputLine = double.Parse(Console.ReadLine());
                box.Add(inputLine);
            }

            var compareElemment = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CompareCounter(compareElemment));
        }
    }
}