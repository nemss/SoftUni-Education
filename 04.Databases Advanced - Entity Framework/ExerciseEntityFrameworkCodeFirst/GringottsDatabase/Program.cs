namespace GringottsDatabase
{
    using System;
    using System.Data.Entity.Validation;
    using GringottsDatabase.Models;
    class Program
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();

            WizardDeposit dumbledore = new WizardDeposit
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpires = false,
            };

            context.WizardeDposits.Add(dumbledore);
            context.SaveChanges();

            
        }
    }
}
