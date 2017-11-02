namespace _8.MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}