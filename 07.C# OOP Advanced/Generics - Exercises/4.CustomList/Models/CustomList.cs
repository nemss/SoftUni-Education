using _4.CustomList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.CustomList.Models
{
    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
    {
        public CustomList()
        {
            this.data = new List<T>();
        }

        private IList<T> data = new List<T>();

        public void Add(T elemelt)
        {
            this.data.Add(elemelt);
        }

        public void Remove(int index)
        {
            var element = data[index];
            this.data.Remove(element);
        }

        public bool Contains(T element)
        {
            if (this.data.Contains(element))
            {
                return true;
            }

            return false;
        }

        public void Swap(int indexOne, int indexTwo)
        {
            var takenElementWithIndexOne = this.data[indexOne];
            var takeElementWithIndexTwo = this.data[indexTwo];

            this.data[indexOne] = takeElementWithIndexTwo;
            this.data[indexTwo] = takenElementWithIndexOne;
        }

        public int Greater(T element)
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

        public void Sort()
        {
            var list = this.data.OrderBy(x => x).ToList();
            this.data = list;
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public string Print()
        {
            var sb = new StringBuilder();

            foreach (var e in this.data)
            {
                sb.AppendLine($"{e}");
            }

            return sb.ToString().Trim();
        }
    }
}