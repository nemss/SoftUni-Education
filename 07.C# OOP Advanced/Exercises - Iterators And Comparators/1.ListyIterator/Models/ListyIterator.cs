using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1.ListyIterator.Models
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collectionsList;
        private int currentIndex;

        public ListyIterator(List<T> collection)
        {
            this.collectionsList = collection;
            this.currentIndex = 0;
        }

        public ListyIterator()
        {
            this.currentIndex = 0;
            this.collectionsList = new List<T>();
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

        public T Print()
        {
            if (this.collectionsList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.collectionsList[this.currentIndex];
        }

        public bool HasNext()
        {
            if (this.collectionsList.Count - 1 > this.currentIndex)
            {
                return true;
            }

            return false;
        }

        public string PrintAll()
        {
            if (this.collectionsList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            var sb = new StringBuilder();
            foreach (var element in this.collectionsList)
            {
                sb.Append($"{element} ");
            }

            return sb.ToString().Trim();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collectionsList.Count; i++)
            {
                yield return this.collectionsList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}