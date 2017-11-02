namespace _3.OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name) : this(name, 19) { }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
