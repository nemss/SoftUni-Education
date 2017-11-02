namespace _9.CollectionHierarchy.Models
{
    using _9.CollectionHierarchy.Interfaces;

    public class AddCollection<T> : Collection<T>, IAddCollection<T>
    {
        public int Add(T element)
        {
            var index = this.Data.Count;
            Data.Insert(index, element);
            return index;
        }
    }
}