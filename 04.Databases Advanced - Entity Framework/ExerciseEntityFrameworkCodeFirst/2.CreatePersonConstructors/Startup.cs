namespace _2.CreatePersonConstructors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 0)
            {
                Person person = new Person();
                Console.WriteLine($"{person.Name} {person.Age}");
            }
            else if (input.Length == 1)
            {
                string argument = input[0];
                int age = -1;

                if(int.TryParse(argument, out age))
                {
                    Person person = new Person(age);
                    Console.WriteLine($"{person.Name} {person.Age}");

                }
                else
                {
                    Person person = new Person(argument);
                    Console.WriteLine($"{person.Name} {person.Age}");
                }
            }
            else if (input.Length == 2)
            {
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
        

         class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public Person() : this ("No name", 1) {}

            public Person(int age) : this("No name", age) { }

            public Person(string name) : this(name, 1) { }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
