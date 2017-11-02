namespace _8.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public double Salary { get; }
        public ICollection<IPrivate> Privates { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            if (this.Privates.Count > 0)
            {
                foreach (var priv in this.Privates)
                {
                    sb.AppendLine($"{priv}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}