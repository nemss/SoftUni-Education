using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listTrainers = new List<Trainer>();
            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("Tournament"))
            {
                var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var trainetName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);
               
                if (!listTrainers.Any(l => l.Name == trainetName))
                {
                    listTrainers.Add(new Trainer(trainetName));
                }

                var trainer = listTrainers.FirstOrDefault(t => t.Name == trainetName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

            }
            string command;
            while (!(command = Console.ReadLine()).Equals("End"))
            {
                foreach (var trainer in listTrainers)
                {
                    if (trainer.ContainsType(command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.DecreaseHealt();
                        trainer.RemovePokemons();
                    }
                }
            }
            listTrainers.OrderByDescending(t => t.NumberOfBadges)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Name} {c.NumberOfBadges} {c.Pokemons.Count}"));
        }
    }
}
