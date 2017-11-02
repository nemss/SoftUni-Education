using System;

namespace _5.Tuple
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            var secondLine = Console.ReadLine().Split(' ');
            var thirdLine = Console.ReadLine().Split(' ');

            var firtsTuple = new Tuple<string, string>(firstLine[0] + " " + firstLine[1], firstLine[2]);
            var secondTuple = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));
            var thirdTuple = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));

            Console.WriteLine(firtsTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}