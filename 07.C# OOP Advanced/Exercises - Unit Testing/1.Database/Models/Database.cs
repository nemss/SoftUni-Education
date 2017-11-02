namespace _1.Database.Models
{
    using _1.Database.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database : IDatabase
    {
        private const int DefaultCapacity = 16;
        private List<int> data;
        private int curentIndex;

        public Database(params int[] elements)
        {
            if (elements.Length > 16)
            {
                throw new InvalidOperationException();
            }

            this.data = new List<int>(elements);
        }

        public int Count()
        {
            return this.data.Count;
        }

        public void Add(int number)
        {
            if (this.data.Count >= DefaultCapacity)
            {
                throw new InvalidOperationException();
            }

            this.data.Add(number);
        }

        public void Remove()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.data.Remove(this.data.Last());
        }

        public int[] Fetch()
        {
            return this.data.ToArray();
        }
    }
}