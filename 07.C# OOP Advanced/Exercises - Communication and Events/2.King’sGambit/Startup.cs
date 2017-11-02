namespace _2.King_sGambit
{
    using _2.King_sGambit.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var army = new List<Soldier>();

            var king = new King(Console.ReadLine());
            var royalGuards = Console.ReadLine()
                .Split()
                .ToList();

            foreach (var royalGuard in royalGuards)
            {
                var guard = new RoyalGuard(royalGuard);
                army.Add(guard);
                king.UnderAttack += guard.KingUnderAttack;
            }

            var footmen = Console.ReadLine()
                .Split()
                .ToList();

            foreach (var footman in footmen)
            {
                var foot = new Footman(footman);
                army.Add(foot);
                king.UnderAttack += foot.KingUnderAttack;
            }

            var command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Kill":
                        var soldier = army.FirstOrDefault(s => s.Name == command[1]);
                        king.UnderAttack -= soldier.KingUnderAttack;
                        army.Remove(soldier);
                        break;

                    case "Attack":
                        king.OnUnderAttack();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}