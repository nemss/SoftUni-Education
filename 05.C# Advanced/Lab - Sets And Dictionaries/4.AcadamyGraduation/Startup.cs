namespace _4.AcadamyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, List<double>> dict = new SortedDictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var evaluation = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                if(!dict.ContainsKey(name))
                {
                    dict.Add(name, evaluation);
                }
                else
                {
                    dict[name] = evaluation;
                }
            }

            foreach (var student in dict)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
