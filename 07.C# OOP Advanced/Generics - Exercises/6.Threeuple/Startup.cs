using System;

namespace _6.Threeuple
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            var secondLine = Console.ReadLine().Split(' ');
            var thirdLine = Console.ReadLine().Split(' ');

            var firstTuple = new Threeuple<string, string, string>(firstLine[0] + " " + firstLine[1], firstLine[2], firstLine[3]);
            var secondTuple =
                new Threeuple<string, int, bool>(secondLine[0], int.Parse(secondLine[1]), secondLine[2] == "drunk");
            var thirdTuple = new Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}