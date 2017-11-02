using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

namespace _12.Google
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listPersons = new List<Person>();
            string inutLine;
            while (!(inutLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inutLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var namePerson = tokens[0];
               
                if (!listPersons.Any(p => p.Name == namePerson))
                {
                    listPersons.Add(new Person(namePerson));
                }

                var person = listPersons.FirstOrDefault(p => p.Name == namePerson);
                var command = tokens[1];
                switch (command)
                {
                    case "company":
                        var nameCompany = tokens[2];
                        var departmentCompany = tokens[3];
                        var salaryCompany = decimal.Parse(tokens[4]);
                        person.Company = new Company(nameCompany, departmentCompany, salaryCompany);
                        break;
                    case "pokemon":
                        var namePokmon = tokens[2];
                        var elementPokemon = tokens[3];
                        person.Pokemons.Add(new Pokemon(namePokmon, elementPokemon));
                        break;
                    case "parents":
                        var nameParent = tokens[2];
                        var birthdayParent = tokens[3];
                        person.Parents.Add(new Parent(nameParent, birthdayParent));
                        break;
                    case "children":
                        var nameChildren = tokens[2];
                        var birthdayChildren = tokens[3];
                        person.Children.Add(new Child(nameChildren, birthdayChildren));
                        break;
                    case "car":
                        var modelCar = tokens[2];
                        var speedCar = int.Parse(tokens[3]);
                        person.Car = new Car(modelCar, speedCar);
                        break;
                }            
            }

            var informationAboutPerson = Console.ReadLine();

            var personInfo = listPersons.FirstOrDefault(p => p.Name == informationAboutPerson);

            Console.WriteLine(personInfo.Name);
            Console.WriteLine("Company:");
            if (personInfo.Company != null)
            {
                Console.WriteLine(personInfo.Company);
            }
            Console.WriteLine("Car:");
            if (personInfo.Car != null)
            {
                Console.WriteLine(personInfo.Car);
            }
            Console.WriteLine("Pokemon:");
            personInfo.Pokemons.ForEach(Console.WriteLine);
            Console.WriteLine("Parents:");
            personInfo.Parents.ForEach(Console.WriteLine);
            Console.WriteLine("Children:");
            personInfo.Children.ForEach(Console.WriteLine);
        }
    }   
}
