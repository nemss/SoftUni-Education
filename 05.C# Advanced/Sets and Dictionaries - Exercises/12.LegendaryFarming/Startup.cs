namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var items = new Dictionary<string, string>();
            var material = new Dictionary<string, int>();
            var othetMaterial = new Dictionary<string, int>();
            var winner = string.Empty;
            
            items.Add("shards", "Shadowmourne");
            items.Add("fragments", "Valanyr");
            items.Add("motes", "Dragonwrath");

            material.Add("shards", 0);
            material.Add("fragments", 0);
            material.Add("motes", 0);

            while (winner == string.Empty)
            {
                var arguments = Console.ReadLine()
                    .Trim()
                    .ToLower()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < arguments.Length; i++)
                {
                    var quantity = int.Parse(arguments[i]);
                    var argMaterial = arguments[++i];

                    switch (argMaterial)
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                            material[argMaterial] += quantity;

                            if (winner == string.Empty && material[argMaterial] >= 250)
                            {
                                winner = argMaterial;
                                material[argMaterial] -= 250;
                            }
                            break;

                        default:
                            if (othetMaterial.ContainsKey(argMaterial))
                            {
                                othetMaterial[argMaterial] += quantity;
                            }
                            else
                            {
                                othetMaterial[argMaterial] = quantity;
                            }
                            break;         
                    }

                    if (winner != string.Empty)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"{items[winner]} obtained!");

            foreach (var m in material.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }

            foreach (var o in othetMaterial.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{o.Key}: {o.Value}");   
            }
        }
    }
}
