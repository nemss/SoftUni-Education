using System;

namespace _1.GenericBox
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var inputLine = int.Parse(Console.ReadLine());
                box.Add(inputLine);
            }

            Console.WriteLine(box);
        }
    }
}