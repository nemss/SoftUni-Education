using System.Linq;

namespace _1.ListyIterator
{
    using _1.ListyIterator.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listIterator = null;
            var inputLine = Console.ReadLine()
                .Split()
                .ToList();

            if (inputLine.Count > 1)
            {
                listIterator = new ListyIterator<string>(inputLine.Skip(1).ToList());
            }
            else
            {
                listIterator = new ListyIterator<string>();
            }

            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("END"))
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;

                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;

                    case "Print":
                        try
                        {
                            Console.WriteLine(listIterator.Print());
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "PrintAll":
                        try
                        {
                            Console.WriteLine(listIterator.PrintAll());
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
        }
    }
}