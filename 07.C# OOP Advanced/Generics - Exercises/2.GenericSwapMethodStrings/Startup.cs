using System;
using System.Linq;

namespace _2.GenericSwapMethodStrings
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var inputLine = (Console.ReadLine());
                box.Add(inputLine);
            }

            var swapIndex = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            box.Swap(swapIndex[0], swapIndex[1]);

            Console.WriteLine(box);
        }
    }
}