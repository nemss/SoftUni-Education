namespace _1.StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine()
                    .Trim()
                    .Split(new[] {" - ", ", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                List<double> grates = new List<double>();

                grates.Add(double.Parse(arguments[1]));
                grates.Add(double.Parse(arguments[2]));
                grates.Add(double.Parse(arguments[3]));
                if (!dict.ContainsKey(arguments[0]))
                {
                    dict[arguments[0]] = grates;
                }
            }

            Console.WriteLine(string.Format($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}|"));

            foreach (var e in dict)
            {
                Console.WriteLine(string.Format($"{e.Key,-10}|{e.Value[0],7:f2}|{e.Value[1],7:f2}|{e.Value[2],7:f2}|{e.Value.Average(),7:f4}|"));
                
               
            }
        }
    }
}
