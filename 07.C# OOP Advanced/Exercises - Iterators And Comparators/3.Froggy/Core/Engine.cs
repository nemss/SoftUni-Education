namespace _3.Froggy.Core
{
    using _3.Froggy.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var inputLine = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake<int> lake = new Lake<int>(inputLine);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}