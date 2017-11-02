namespace _5.StrategyPattern.Models
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}