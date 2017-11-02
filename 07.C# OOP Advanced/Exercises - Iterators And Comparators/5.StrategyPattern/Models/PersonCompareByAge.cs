namespace _5.StrategyPattern.Models
{
    using System.Collections.Generic;

    internal class PersonCampareByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var resul = x.Age.CompareTo(y.Age);

            return resul;
        }
    }
}