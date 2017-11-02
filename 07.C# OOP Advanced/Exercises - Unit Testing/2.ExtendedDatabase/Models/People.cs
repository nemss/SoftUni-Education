using _2.ExtendedDatabase.Interfaces;

namespace _2.ExtendedDatabase.Models
{
    public class People : IPeople
    {
        public People(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; }
        public int Id { get; }
    }
}