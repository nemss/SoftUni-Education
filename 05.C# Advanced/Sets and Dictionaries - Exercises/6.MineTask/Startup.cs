namespace _6.MineTask
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (!input.Equals("stop"))
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, quantity);
                }
                else
                {
                    int lastQuantity = dict[input];
                    dict[input] = lastQuantity + quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}
