namespace _3.OldestFamilyMember
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            var numberOfPerson = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPerson; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                family.AddMember(new Person(name, age));
            }

            var oldestMan = family.GetOldestMember();
            Console.WriteLine($"{oldestMan.Name} {oldestMan.Age}");
        }
    }
}

