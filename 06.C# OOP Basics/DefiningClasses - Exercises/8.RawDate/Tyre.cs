namespace _8.RawDate
{
    public class Tyre
    {
        private int age;
        private double pressure;

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
