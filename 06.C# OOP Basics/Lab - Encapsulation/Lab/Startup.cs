using System.Collections.Generic;
using System;

public class Startup
{
    public static void Main(string[] args)
    {
        var listPersons = new List<Person>();
        var numberOfPerson = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPerson; i++)
        {
            var infoPerson = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstName = infoPerson[0];
            var lastName = infoPerson[1];
            var age = int.Parse(infoPerson[2]);
            var salary = double.Parse(infoPerson[3]);

            listPersons.Add(new Person(firstName, lastName, age, salary));
        }

        var team = new Team("Botev");
        foreach (var person in listPersons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine(team.ToString());
       
    }
}



