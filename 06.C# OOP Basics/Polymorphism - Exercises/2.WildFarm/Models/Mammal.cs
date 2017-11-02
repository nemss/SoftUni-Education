namespace _2.WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public Mammal(string animalName, double weight, string livingRegion) 
            : base(animalName, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name}[{this.AnimalName}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
