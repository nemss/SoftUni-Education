namespace _6.EqualityLogic
{
    using System;

    public class Person : IComparable<Person>

    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }

        public override int GetHashCode()
        {
            return this.Name.Length * this.Age;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Person;

            if (item == null)
            {
                return false;
            }

            return this.Name.Equals(item.Name) && this.Age.Equals(item.Age);
        }

        public int CompareTo(Person other)
        {
            return this.Compare(this, other);
        }

        public int Compare(Person first, Person second)
        {
            if (first.Name.CompareTo(second.Name) != 0)
            {
                return first.Name.CompareTo(second.Name);
            }

            return first.Age.CompareTo(second.Age);
        }
    }
}