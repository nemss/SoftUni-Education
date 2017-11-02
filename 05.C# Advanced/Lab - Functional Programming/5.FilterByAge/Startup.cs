namespace _5.FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

                people[input[0]] = int.Parse(input[1]);
            }

            var conditional = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(conditional, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            InvokePrinter(people, tester, printer);
        }

        private static void InvokePrinter(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var p in people)
            {
                if (tester(p.Value))
                {
                    printer(p);
                }
            }
        }


        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                case "name":
                    return p => Console.WriteLine($"{p.Key}");
                case "age":
                    return p => Console.WriteLine($"{p.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string conditional, int age)
        {
            if (conditional == "older")
            {
                return n => n >= age;
            }
            else
            {
                return n => n <= age;
            }
        }
    }
}
