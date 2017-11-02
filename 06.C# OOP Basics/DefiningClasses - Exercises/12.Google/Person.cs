namespace _12.Google
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Children = new List<Child>();
            this.Parents = new List<Parent>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
}
