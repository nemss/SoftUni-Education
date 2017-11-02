using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CirclesIntersection
{
    class IntersextionCircles
    {
        static void Main(string[] args)
        {
            int[] firstCircleParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondCircleParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point firstPoint = new Point
            {
                x = firstCircleParams[0],
                y = firstCircleParams[1]
            };

            Circle firstCircle = new Circle
            {
                radious = firstCircleParams[2],
                Centre = firstPoint
            };

            Point secondPoint = new Point
            {
                x = secondCircleParams[0],
                y = secondCircleParams[1]
            };

            Circle secondCircle = new Circle
            {
                radious = secondCircleParams[2],
                Centre = secondPoint
            };

            if(Circle.Intersect(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    public class Circle
    {
        public int radious { get; set; }
        public Point Centre { get; set; }

        public static bool Intersect(Circle firstCircle, Circle secondCircle)
        {
            int deltaX = Math.Abs(firstCircle.Centre.x - secondCircle.Centre.x);
            int deltaY = Math.Abs(secondCircle.Centre.y - firstCircle.Centre.y);

            double distance = Math.Sqrt(deltaY * deltaY + deltaX * deltaX);
            int radiusSum = firstCircle.radious + secondCircle.radious;

            if(distance <= radiusSum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
