namespace _1.UniqueUsernames
{
    using System;
    using System.Collections.Generic;
    
    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                hashSet.Add(name);
            }

            foreach (var name in hashSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
