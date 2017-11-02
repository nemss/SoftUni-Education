namespace _4.CustomList.Interfaces
{
    public interface ICustomList<T>
    {
        void Add(T elemelt);

        void Remove(int index);

        bool Contains(T element);

        void Swap(int indexOne, int indexTwo);

        int Greater(T element);

        void Sort();

        T Max();

        T Min();

        string Print();
    }
}