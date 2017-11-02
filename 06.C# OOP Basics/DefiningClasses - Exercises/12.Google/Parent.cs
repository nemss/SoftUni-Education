namespace _12.Google
{
    public class Parent
    {
        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Birthday;
        }
    }
}
