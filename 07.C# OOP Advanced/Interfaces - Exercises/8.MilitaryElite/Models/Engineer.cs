namespace _8.MilitaryElite.Models
{
    using _8.MilitaryElite.Enum;
    using _8.MilitaryElite.Models.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IIngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            if (this.Repairs.Count > 0)
            {
                foreach (var repair in this.Repairs)
                {
                    sb.AppendLine($"{repair}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}