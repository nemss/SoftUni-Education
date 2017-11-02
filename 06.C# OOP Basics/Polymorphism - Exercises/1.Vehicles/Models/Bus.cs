namespace _1.Vehicles.Models
{
    using System;

    public class Bus : Vehicle
    {
        private const double AcConsumption = 1.4;

        public Bus(double fuelQuantity, double leterPerKm, double tankCapacity)
            : base(fuelQuantity, leterPerKm, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            if (this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit in tank");
            }
            base.Refuel(fuel);
        }

        protected override bool Drive(double distance, bool isAcOn)
        {
            var requireFuel = 0d;
            if (isAcOn)
            {
                requireFuel = distance * (this.LeterPerKm + AcConsumption);
            }
            else
            {
                requireFuel = distance * this.LeterPerKm;
            }

            if (requireFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= requireFuel;
                return true;
            }

            return false;
        }
    }
}
