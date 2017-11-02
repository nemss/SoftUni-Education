using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.DistanceBetweenPoints
{
    class DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();

            double distance = CalcDistance(p1, p2);

            Console.WriteLine("Distance: {0:f3}", distance);

        }
        static Point ReadPoint()
        {
            var coords = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var p = new Point() { X = coords[0], Y = coords[1] };
            return p;
        }

        static double CalcDistance(Point p1, Point p2)
        {
            double deltaX = p2.X - p1.X;
            double deltaY = p2.Y - p1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }


    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
