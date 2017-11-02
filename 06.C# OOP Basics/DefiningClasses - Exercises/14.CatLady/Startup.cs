namespace _14.CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var listOfCat = new List<Cat>();           
            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var typeOfCat = tokens[0];
                var nameCat = tokens[1];

                switch (typeOfCat)
                {
                    case "Siamese":
                        listOfCat.Add(new Siamese(nameCat, long.Parse(tokens[2])));
                        break;
                    case "Cymric":
                        listOfCat.Add(new Cymric(nameCat, double.Parse(tokens[2])));
                        break;
                    case "StreetExtraordinaire":
                        listOfCat.Add(new StreetExtraordinaire(nameCat, double.Parse(tokens[2])));
                        break;
                }
            }

            var catName = Console.ReadLine();
            listOfCat.Where(c => c.Name == catName)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.ToString()}"));
        }
    }
}
