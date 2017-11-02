namespace _1.EventImplementation
{
    public class NameChangeEventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}