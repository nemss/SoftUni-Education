using System;
using System.Collections.Generic;

namespace _3.GenericCountMethod
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public int CompareCounter(double element)
        {
            var count = 0;

            foreach (var el in this.data)
            {
                if (el.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}