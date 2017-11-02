using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //string dateAsText = Console.ReadLine();
            //DateTime date = DateTime.ParseExact(dateAsText, "d-M-yyyy", CultureInfo.InvariantCulture);
            //Console.WriteLine(date.DayOfWeek);

            var dataStr = Console.ReadLine();
            var tokens = dataStr.Split('-').Select(int.Parse).ToArray();
            var date = new DateTime(tokens[2], tokens[1], tokens[0]);
            Console.WriteLine(date.DayOfWeek);
                
        }
    }
}
