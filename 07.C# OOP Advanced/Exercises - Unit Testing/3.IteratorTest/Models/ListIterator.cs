using _3.IteratorTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.IteratorTest.Models
{
    public class ListIterator : IListIterator
    {
        private readonly IList<string> data;
        private int currentIndex;

        public ListIterator(IList<string> data)
        {
            this.data = new List<string>();
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.data.Count - 1 > this.currentIndex)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentNullException("Invalid Operation!");
            }

            var sb = new StringBuilder();
            foreach (var element in this.data)
            {
                sb.Append($"{element} ");
            }

            return sb.ToString().Trim();
        }
    }
}