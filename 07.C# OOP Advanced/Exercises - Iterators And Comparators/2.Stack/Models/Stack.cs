namespace _2.Stack.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Stack<T> : IEnumerable<T>
    {
        private readonly List<T> collection;

        public Stack()
        {
            this.collection = new List<T>();
        }

        public void Push(List<T> elements)
        {
            foreach (var element in elements)
            {
                this.collection.Add(element);
            }
        }

        public void Pop()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            var lastElement = this.collection.Last();
            this.collection.Remove(lastElement);
        }

        public string PrintAllElements()
        {
            var sb = new StringBuilder();
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                sb.AppendLine($"{collection[i]}");
            }

            return sb.ToString().Trim();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}