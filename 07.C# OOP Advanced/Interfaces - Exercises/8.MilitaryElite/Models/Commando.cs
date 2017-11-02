namespace _8.MilitaryElite.Models
{
    using _8.MilitaryElite.Enum;
    using _8.MilitaryElite.Models.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            if (this.Missions.Count > 0)
            {
                foreach (var mission in this.Missions)
                {
                    sb.AppendLine($"{mission}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}