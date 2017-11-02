namespace Gringotts
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();

            //Exercise 19
            //DepositSumForOllivanderFamily(context);

            //Exercise 20
            //DepositFilter(context);
        }

        private static void DepositFilter(GringottsContext context)
        {
            var wizzard = context.WizzardDeposits
               .Where(w => w.MagicWandCreator == "Ollivander family")
               .GroupBy(w => w.DepositGroup)
               .Select(c => new
               {
                   DepositGroup = c.Key,
                   TotalSum = c.Sum(s => s.DepositAmount)
               })
               .Where(w => w.TotalSum < 150000)
               .OrderByDescending(w => w.TotalSum);


            foreach (var w in wizzard)
            {
                Console.WriteLine($"{w.DepositGroup} - {w.TotalSum} ");
            }
        }
        private static void DepositSumForOllivanderFamily(GringottsContext context)
        {
            var wizzard = context.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(c => new
                {
                    DepositGroup = c.Key,
                    TotalSum = c.Sum(s => s.DepositAmount)
                });
                

            foreach (var w in wizzard)
            {
                Console.WriteLine($"{w.DepositGroup} - {w.TotalSum} ");
            }
        }
    }
}
