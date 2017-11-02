namespace _8.LinkedListTraversal.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            this.data = new List<T>();
        }

        private List<T> data;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public bool Remove(T element)
        {
            if (!this.data.Contains(element))
            {
                return false;
            }

            this.data.Remove(element);
            return true;
        }

        public int Count => this.data.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}