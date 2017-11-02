using _9.CollectionHierarchy.Interfaces;
using System.Linq;

namespace _9.CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : Collection<T>, IAddRemoveCollection<T>
    {
        public int Add(T element)
        {
            this.Data.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            var elementToRemove = this.Data.LastOrDefault();
            this.Data.RemoveAt(this.Data.Count - 1);
            return elementToRemove;
        }
    }
}