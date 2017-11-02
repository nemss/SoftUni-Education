namespace _03.Ferrari.Models
{
    using System.Text;

    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"488-Spider/{this.Brakes()}/{this.PushTheGasPedal()}/{this.DriverName}");

            return sb.ToString().Trim();
        }
    }
}