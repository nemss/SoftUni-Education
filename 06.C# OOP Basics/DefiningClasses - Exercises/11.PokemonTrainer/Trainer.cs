namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public bool ContainsType(string type)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Element == type)
                {
                    return true;
                }
            }
            return false;
        }

        public void DecreaseHealt()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public void RemovePokemons()
        {
            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
        }
    }
}
