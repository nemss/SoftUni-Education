namespace _3.OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            this.person = new List<Person>();
        }

        private List<Person> person;

        public List<Person> Person
        {
            get { return this.person; }
            set { this.person = value; }
        }

        public void AddMember(Person member)
        {
            this.person.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.person.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
