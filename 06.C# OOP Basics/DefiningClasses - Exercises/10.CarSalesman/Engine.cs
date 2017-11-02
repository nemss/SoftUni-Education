namespace _10.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficienty = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficienty)
            : this(model, power)
        {
            this.Efficienty = efficienty;
        }

        public Engine(string model, int power, int displacement, string efficienty)
            : this(model, power, displacement)
        {
            this.Efficienty = efficienty;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficienty { get; set; }
    }
}
