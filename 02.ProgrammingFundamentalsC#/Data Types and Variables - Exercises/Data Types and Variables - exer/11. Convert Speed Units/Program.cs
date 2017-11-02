using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int allSeconds = (hours * 3600 + minutes * 60 + seconds);

            float metersPerSecond = (float)meters/ allSeconds;
            float kilometersPerHour = ((float)meters / 1000) / ((float)allSeconds / 3600);
            float milesPerHour = ((float)meters/1609)/ ((float)allSeconds / 3600);

            Console.WriteLine(metersPerSecond);
            Console.WriteLine(kilometersPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
