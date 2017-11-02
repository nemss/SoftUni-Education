namespace _1.DefineAclassPerson
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
            Person firstPerson = new Person()
            {
                Name = "Pesho",
                Age = 20,
            };

            PersonConstructor secondPerson = new PersonConstructor("Gosho", 18);

            PersonConstructor thirdPerson = new PersonConstructor("Stamat", 43);

            Console.WriteLine(firstPerson.Name);
            Console.WriteLine(firstPerson.Age);
            Console.WriteLine(new string('-', 20));

            Console.WriteLine(secondPerson.Name);
            Console.WriteLine(secondPerson.Age);
            Console.WriteLine(new string('-', 20))
                ;
            Console.WriteLine(thirdPerson.Name);
            Console.WriteLine(thirdPerson.Age);

            
        }

        public class Person
        { 
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class PersonConstructor
        {
            public PersonConstructor(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
