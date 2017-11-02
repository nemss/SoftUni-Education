namespace _7.FoodShortage.Models
{
    public class Rebel : IIhabitant, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Group { get; private set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            return this.Food = 5;
        }
    }
}