namespace _6.BirthdayCelebrations.Models
{
    public class Pet : IInhabitant, IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; }
        public string Birthday { get; }
    }
}