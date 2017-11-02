namespace _7.FoodShortage.Models
{
    public class Citizen : IIhabitant, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
        public int Food { get; set; }

        public int BuyFood()
        {
            return this.Food = 10;
        }
    }
}