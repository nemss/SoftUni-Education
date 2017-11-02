using System.Collections.Generic;

namespace _9.CollectionHierarchy.Models
{
    public abstract class Collection<T>
    {
        public Collection()
        {
            this.data = new List<T>();
        }

        private List<T> data;

        public List<T> Data
        {
            get { return this.data; }
        }
    }
}