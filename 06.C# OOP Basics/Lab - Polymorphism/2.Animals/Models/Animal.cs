﻿namespace _2.Animals.Models
{
    public class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        private string name;
        private string favouriteFood;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string FavouriteFood
        {
            get { return this.favouriteFood; }
            set { this.favouriteFood = value; }
        }

        public virtual string ExplainMyself()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
