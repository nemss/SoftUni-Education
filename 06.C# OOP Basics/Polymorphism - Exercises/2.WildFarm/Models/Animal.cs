namespace _2.WildFarm.Models
{
    public abstract class Animal
    {
        protected Animal(string animalName, double weight)
        {
            this.AnimalName = animalName;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string AnimalName { get; set; }

        public double Weight { get; set; }

        public int  FoodEaten { get; set; }

        public abstract void MakeSound();

        public abstract void Eat(Food food);
    }
}
