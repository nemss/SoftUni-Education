using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;

namespace _9.RectangleIntersection
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfRectangle = new List<Rectangle>();
            var inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbersOfRectangles = int.Parse(inputLine[0]);
            var intersectionCheck = int.Parse(inputLine[1]);

            for (int i = 0; i < numbersOfRectangles; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var width = double.Parse(tokens[1]);
                var height = double.Parse(tokens[2]);
                var x = double.Parse(tokens[3]);
                var y = double.Parse(tokens[4]);

                var rectangle = new Rectangle(name, width, height, x, y);
                listOfRectangle.Add(rectangle);
            }

            for (int i = 0; i < intersectionCheck; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var firstRec = listOfRectangle.FirstOrDefault(r => r.ID == tokens[0]);
                var secondRec = listOfRectangle.FirstOrDefault(r => r.ID == tokens[1]);
                Console.WriteLine(firstRec.Intersevtion(secondRec));
            }
        }
    }   
}
