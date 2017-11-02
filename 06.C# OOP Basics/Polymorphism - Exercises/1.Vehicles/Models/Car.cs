namespace _1.Vehicles.Models
{
    using System;

    public class Car : Vehicle
    {
        private const double AcConsumption = 0.9;

        public Car(double fuelQuantity, double leterPerKm, double tankCapacity)
            : base(fuelQuantity, leterPerKm + AcConsumption, tankCapacity)
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
    }
}
