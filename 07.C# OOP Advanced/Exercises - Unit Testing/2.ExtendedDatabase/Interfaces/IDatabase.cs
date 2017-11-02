namespace _2.ExtendedDatabase.Interfaces
{
    public interface IDatabase
    {
        int Count();

        void Add(IPeople people);

        void Remove();

        IPeople FindByUsername(string username);

        IPeople FindById(int Id);
    }
}