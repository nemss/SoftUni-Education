namespace _7.SpeedRacing
{
    using System;

    public class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.DistanceTravel = 0;
        }
        private string model;
        private decimal fuelAmount;
        private decimal fuelConsumption;
        private decimal distanceTravel;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public decimal FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public decimal FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public decimal DistanceTravel
        {
            get { return this.distanceTravel; }
            set { this.distanceTravel = value; }
        }

        public void Drive(decimal distanse)
        {
            if (this.FuelAmount < distanse * this.FuelConsumption)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distanse * this.fuelConsumption;
                this.DistanceTravel += distanse;
            }
        }
    }
}
