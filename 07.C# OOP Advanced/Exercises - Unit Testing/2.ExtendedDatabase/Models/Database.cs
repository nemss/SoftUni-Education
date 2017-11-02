using System;
using System.Collections.Generic;

namespace _2.ExtendedDatabase.Models
{
    using _2.ExtendedDatabase.Interfaces;
    using System.Linq;

    public class Database : IDatabase
    {
        private IList<IPeople> persons;

        public Database()
        {
            this.persons = new List<IPeople>();
        }

        public int Count() => this.persons.Count;

        public void Add(IPeople people)
        {
            if (persons.FirstOrDefault(p => p.Id == people.Id
                                            || p.Name == people.Name) != null)
            {
                throw new InvalidOperationException();
            }

            this.persons.Add(people);
        }

        public void Remove()
        {
            if (this.persons.Count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.persons.Remove(this.persons.Last());
        }

        public IPeople FindByUsername(string username)
        {
            var currentUser = this.persons.FirstOrDefault(p => p.Name == username);

            if (currentUser == null)
            {
                throw new InvalidOperationException();
            }

            if (username == null)
            {
                throw new ArgumentNullException();
            }

            return currentUser;
        }

        public IPeople FindById(int Id)
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentUser = this.persons.FirstOrDefault(p => p.Id == Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException();
            }

            return currentUser;
        }
    }
}