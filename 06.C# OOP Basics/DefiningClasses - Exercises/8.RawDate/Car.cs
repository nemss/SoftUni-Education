namespace _8.RawDate
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        public Engine engine;
        public Cargo cargo;
        public List<Tyre> tires;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Car(string model, Engine engine, Cargo cargo, List<Tyre> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
    }
}
