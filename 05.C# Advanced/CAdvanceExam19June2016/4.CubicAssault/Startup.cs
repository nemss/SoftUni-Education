namespace _4.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static int ConvertThreshold = 1_000_000;
        public static void Main(string[] args)
        {
            var meteorNames = new List<string>(){"Green", "Red", "Black"};
            var dic = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();
            while (!input.Equals("Count em all"))
            {
                var tokens = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);

                var regionName = tokens[0];
                var meteorType = tokens[1];
                var meteorCount = int.Parse(tokens[2]);

                if (!dic.ContainsKey(regionName))                            
                {
                    dic[regionName] = new Dictionary<string, long>() {{"Green", 0}, {"Red", 0}, {"Black", 0}};
                }
                dic[regionName][meteorType] += meteorCount;

                for (int i = 0; i < meteorNames.Count - 1; i++)
                {
                    var nextTypeCount = dic[regionName][meteorNames[i]] / ConvertThreshold;

                    if (nextTypeCount > 0)
                    {
                        dic[regionName][meteorNames[i + 1]] += nextTypeCount;
                        dic[regionName][meteorNames[i]] %= ConvertThreshold;
                    }
                }
               
     
                input = Console.ReadLine();
            }

            var orderedRegions = dic
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);

                foreach (var mateorType in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {mateorType.Key} : {mateorType.Value}");
                }
            }
        }
    }
}
