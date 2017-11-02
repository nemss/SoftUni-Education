namespace _8.MilitaryElite.Models
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }
    }
}