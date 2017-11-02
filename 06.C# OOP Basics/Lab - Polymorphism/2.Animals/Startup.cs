namespace _2.Animals
{
    using System;
    using _2.Animals.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");
           
            Console.WriteLine(cat.ExplainMyself());
            Console.WriteLine(dog.ExplainMyself());
        }
    }
}
