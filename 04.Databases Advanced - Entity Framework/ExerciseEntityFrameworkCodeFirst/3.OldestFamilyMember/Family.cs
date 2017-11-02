namespace _3.OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }
        public void AddMemer(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestPerson()
        {
            return this.Members.OrderByDescending(m => m.Age).FirstOrDefault();
        }

        public List<Person> Members { get { return members; } }
    }
}
