using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centures = byte.Parse(Console.ReadLine());
            int years = 100 * centures;
            int days = (int)((double)(years*365.2422));
            ulong hours = (ulong)days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            decimal milliseconds = seconds * 1000;
            decimal microseconds = milliseconds * 1000;
            decimal nanoseconds = microseconds * 1000;
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",centures,years,days,hours,minutes,seconds,milliseconds,microseconds,nanoseconds);
        }
    }
}
