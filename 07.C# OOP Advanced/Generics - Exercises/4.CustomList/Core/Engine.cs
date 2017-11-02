using _4.CustomList.Models;
using System;

namespace _4.CustomList.Core
{
    public class Engine
    {
        private CustomList<string> customList;

        public Engine()
        {
            this.customList = new CustomList<string>();
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var tokens = Console.ReadLine().Split(' ');
                var command = tokens[0];

                switch (command)
                {
                    case "Add":
                        customList.Add(tokens[1]);
                        break;

                    case "Remove":
                        customList.Remove(int.Parse(tokens[1]));
                        break;

                    case "Contains":
                        Console.WriteLine(customList.Contains(tokens[1]));
                        break;

                    case "Swap":
                        customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;

                    case "Greater":
                        Console.WriteLine(customList.Greater(tokens[1]));
                        break;

                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;

                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;

                    case "Sort":
                        customList.Sort();
                        break;

                    case "Print":
                        Console.WriteLine(customList.Print());
                        break; ;
                    case "END":
                        isRunning = false;
                        break;
                }
            }
        }
    }
}