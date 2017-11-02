namespace _4.CompatingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
                if (result == 0)
                {
                    result = this.Town.CompareTo(other.Town);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Town}";
        }
    }
}