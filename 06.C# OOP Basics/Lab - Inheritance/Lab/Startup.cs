
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Eat();
            dog.Bark();

            var cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking");
        }
    }

    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("eating");
        }
    }

    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("meowing");
        }
    }

