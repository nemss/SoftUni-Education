namespace _3.Mankind
{
    using System;

    public class Student : Human
    {
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        private string facultyNumber;

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10 || !IsValidFacultyNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        private bool IsValidFacultyNumber(string value)
        {
            bool isValidFacultyNumber = true;
            foreach (char ch in value)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    isValidFacultyNumber = false;
                }
            }

            return isValidFacultyNumber;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First Name: {base.FirstName}");
            stringBuilder.AppendLine($"Last Name: {base.LastName}");
            stringBuilder.AppendLine($"Faculty number: {this.FacultyNumber}");

            return stringBuilder.ToString();
        }
    }
}
