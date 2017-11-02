namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        private const int DefaultDamage = 45;
        private const int DefaultHealth = 250;
        private const int DefaultArmor = 10;
        public static void Main(string[] args)
        {
            var allDragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            var numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                var dragon = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var dragonType = dragon[0];
                var dragonName = dragon[1];
                var dragonDamage = dragon[2].Equals("null") ? DefaultDamage : int.Parse(dragon[2]);
                var dragonHealth = dragon[3].Equals("null") ? DefaultHealth : int.Parse(dragon[3]);
                var drgonArmor = dragon[4].Equals("null") ? DefaultArmor : int.Parse(dragon[4]);

              
                    if (allDragons.ContainsKey(dragonType))
                    {
                        allDragons[dragonType][dragonName] = new[] {dragonDamage, dragonHealth, drgonArmor};
                    }
                    else
                    {
                        allDragons[dragonType] = new SortedDictionary<string, int[]>() {{dragonName, new int[] { dragonDamage, dragonHealth, drgonArmor}}};
                    }
            }

            PrintAllDragons(allDragons);
        }

        private static void PrintAllDragons(Dictionary<string, SortedDictionary<string, int[]>> allDragons)
        {
            foreach (var dragonType in allDragons)
            {
                var dragonTypeInfo = new StringBuilder();
                double avrDamege = 0, avrHealt = 0, avrArmor = 0;
                foreach (var dragon in dragonType.Value)
                {
                    dragonTypeInfo.Append(
                        $"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}\r\n");
                    avrDamege += dragon.Value[0];
                    avrHealt += dragon.Value[1];
                    avrArmor += dragon.Value[2];
                }

                avrDamege /= dragonType.Value.Count;
                avrHealt /= dragonType.Value.Count;
                avrArmor /= dragonType.Value.Count;

                Console.WriteLine($"{dragonType.Key}::({avrDamege:f2}/{avrHealt:f2}/{avrArmor:f2})");
                Console.Write(dragonTypeInfo.ToString());
            }
        }
    }
}
