namespace _3.Mankind
{
    using System;
    using System.Text;
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
            : base(firstName, lastName)
        {
            this.Salary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        private double housrPerDay;
        private double salary;



        public double HoursPerDay
        {
            get { return this.housrPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.housrPerDay = value;
            }
        }

       
        public double Salary
        {
            get { return this.salary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.salary = value;
            }
        }       

        public double GetSalaryPerHour()
        {
            return this.Salary / (this.HoursPerDay * 5);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First Name: {base.FirstName}");
            stringBuilder.AppendLine($"Last Name: {base.LastName}");
            stringBuilder.AppendLine($"Week Salary: {this.Salary:f2}");
            stringBuilder.AppendLine($"Hours per day: {this.HoursPerDay:f2}");
            stringBuilder.Append($"Salary per hour: {this.GetSalaryPerHour():f2}");

            return stringBuilder.ToString();
        }
    }
}
