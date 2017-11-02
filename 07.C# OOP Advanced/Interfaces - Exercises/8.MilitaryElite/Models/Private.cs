namespace _8.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public double Salary { get; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}