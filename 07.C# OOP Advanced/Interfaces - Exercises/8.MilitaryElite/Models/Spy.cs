namespace _8.MilitaryElite.Models
{
    using _8.MilitaryElite.Models.Interfaces;
    using System;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
        }
    }
}