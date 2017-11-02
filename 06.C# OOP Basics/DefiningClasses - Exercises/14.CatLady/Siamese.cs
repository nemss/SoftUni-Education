namespace _14.CatLady
{
    public class Siamese : Cat
    {
        public Siamese(string name, long earSize)
            : base(name)
        {
            this.EarSize = earSize;
            this.Type = "Siamese";
        }

        public string Type { get; set; }
        public long EarSize { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.EarSize}";
        }
    }
}
