using _6.Animals.Models;

namespace _6.Animals
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string type;
            while (!(type = Console.ReadLine()).Equals("Beast!"))
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                try
                {
                    Animal animal = null;
                    switch (type)
                    {
                        case "Cat":
                            animal = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                            ;
                        case "Dog":
                            animal = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                        case "Frog":
                            animal = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                            ;
                        case "Kittens":
                            animal = new Kitten(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                    Console.WriteLine(animal);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
