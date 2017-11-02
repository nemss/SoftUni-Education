namespace _12.Google
{
    public class Child
    {
        public Child(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
