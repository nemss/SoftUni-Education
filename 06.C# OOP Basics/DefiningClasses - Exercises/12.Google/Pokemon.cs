namespace _12.Google
{
    public class Pokemon
    {
        public Pokemon(string name, string element)
        {
            this.Name = name;
            this.Element = element;
        }

        public string Name { get; set; }
        public string Element { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Element;
        }
    }
}
