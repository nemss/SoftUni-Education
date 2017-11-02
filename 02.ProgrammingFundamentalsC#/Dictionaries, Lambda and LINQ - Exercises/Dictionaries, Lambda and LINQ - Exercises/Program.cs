using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries__Lambda_and_LINQ___Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            string resourseType = Console.ReadLine();

            while (!resourseType.Equals("stop"))
            {
                long resourseQuantity = long.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resourseType))
                {
                    resources[resourseType] = 0;
                }
                resources[resourseType] += resourseQuantity;

                resourseType = Console.ReadLine();
        

            }

            foreach (var entry in resources)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
