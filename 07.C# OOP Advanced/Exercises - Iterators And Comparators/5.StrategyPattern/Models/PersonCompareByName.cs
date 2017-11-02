namespace _5.StrategyPattern.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCompareByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                result = x.Name.ToLower().FirstOrDefault().CompareTo(y.Name.ToLower().FirstOrDefault());
            }

            return result;
        }
    }
}