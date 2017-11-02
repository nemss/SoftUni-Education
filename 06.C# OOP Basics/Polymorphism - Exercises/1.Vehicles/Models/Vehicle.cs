namespace _1.Vehicles.Models
{
    using System;
    using System.Linq;

    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double leterPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.LeterPerKm = leterPerKm;
        }

        private double fuelQuantity;
        private double leterPerKm;
        private double tankCapacity;

        public virtual double TankCapacity
        {
            get { return this.tankCapacity; }
            set { this.tankCapacity = value; }
        }


        public virtual double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set { this.fuelQuantity = value; }
        }

        public double LeterPerKm
        {
            get { return this.leterPerKm; }
            protected set { this.leterPerKm = value; }
        }

        protected virtual bool Drive(double distance, bool isAcOn)
        {
            var fuelRequired = distance * this.LeterPerKm;
            if (fuelRequired <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelRequired;
                return true;
            }

            return false;
        }

        public string TryTravelDistance(double distance, bool isAcOn)
        {
            if (this.Drive(distance, isAcOn))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public string TryTravelDistance(double distance)
        {
            return this.TryTravelDistance(distance, true);
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
