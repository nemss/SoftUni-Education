using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace _6.Animals.Models
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string name;
        private int age;
        private string gender;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();
    

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{GetType().Name}");
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.Append($"{this.ProduceSound()}");

            return stringBuilder.ToString(); 
        }
    }
}
