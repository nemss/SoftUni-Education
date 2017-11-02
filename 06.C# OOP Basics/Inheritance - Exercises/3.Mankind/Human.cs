namespace _3.Mankind
{
    using System;

    public class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {               
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                this.lastName = value;
            }
        }

    }
}
