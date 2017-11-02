namespace _01.SchoolCompetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var studentsScore = new Dictionary<string, int>();
            var studentsCategory = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var parts = line.Split();

                var name = parts[0];
                var category = parts[1];
                var score = int.Parse(parts[2]);

                if (!studentsScore.ContainsKey(name))
                {
                    studentsScore[name] = 0;
                }

                studentsScore[name] += score;

                if (!studentsCategory.ContainsKey(name))
                {
                    studentsCategory[name] = new HashSet<string>();
                }

                studentsCategory[name].Add(category);
            }

            var orderByPoints = studentsScore
                .OrderByDescending(s => s.Value)
                .ThenBy(s => s.Key);

            foreach (var student in orderByPoints)
            {
                var orderCategories = studentsCategory[student.Key]
                    .OrderBy(c => c);

                Console.WriteLine($"{student.Key}: {student.Value} [{string.Join(", ", orderCategories)}]");
            }
        }
    }
}