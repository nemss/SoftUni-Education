namespace _8.RawDate
{
    public class Cargo
    {
        private double weight;
        private string type;

        public double Weight
        {

            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public Cargo(double weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
