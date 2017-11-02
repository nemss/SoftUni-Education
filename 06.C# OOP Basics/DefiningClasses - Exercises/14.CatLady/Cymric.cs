namespace _14.CatLady
{
    public class Cymric : Cat
    {
        public Cymric(string name, double furLength)
            : base(name)
        {
            this.FurLength = furLength;
            this.Type = "Cymric";
        }
        public double FurLength { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.FurLength:f2}";
        }
    }
}
