namespace _1.Vehicles.Models
{
    using System;

    public class Truck : Vehicle
    {
        private const double AcConsumption = 1.6;
        private const double FuelLossFactor = 0.95;

        public Truck(double fuelQuantity, double leterPerKm, double tankCapacity) 
            : base(fuelQuantity, leterPerKm + AcConsumption, tankCapacity)
        {
        }


        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * FuelLossFactor);
        }
    }
}
