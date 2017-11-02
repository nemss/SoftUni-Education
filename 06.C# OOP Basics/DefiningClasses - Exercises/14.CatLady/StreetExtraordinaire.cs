namespace _14.CatLady
{
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string name, double decibelOfMeows)
            : base(name)
        {
            this.DecibelOfMeows = decibelOfMeows;
            this.Type = "StreetExtraordinaire";
        }

        public string Type { get; set; }
        public double DecibelOfMeows { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.DecibelOfMeows}";
        }
    }
}
