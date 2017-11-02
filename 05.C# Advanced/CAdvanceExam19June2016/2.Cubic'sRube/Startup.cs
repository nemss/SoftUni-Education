namespace _2.Cubic_sRube
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var dimensionSize = int.Parse(Console.ReadLine());
            var sumOfParticles = 0L;
            var countChange = 0;

            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("Analyze"))
            {
                var tokens = inputLine
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (tokens.Take(3).Any(p => p < 0 || p > dimensionSize))
                {
                    continue;
                }

                if (tokens[3] != 0)
                {
                    sumOfParticles += tokens[3];
                    countChange++;
                }
            }

            Console.WriteLine(sumOfParticles);
            Console.WriteLine(Math.Pow(dimensionSize, 3) - countChange);
        }
    }
}
