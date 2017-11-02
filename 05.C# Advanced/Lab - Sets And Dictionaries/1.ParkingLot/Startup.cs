namespace _1.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            SortedSet<string> parkingLot = new SortedSet<string>();

            
            while(input != "END")
            {
                var arguments = input
                    .Trim()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(arguments[0] == "IN")
                {
                    parkingLot.Add(arguments[1]);
                }
                else if(arguments[0] == "OUT")
                {
                    if(parkingLot.Contains(arguments[1]))
                    {
                        parkingLot.Remove(arguments[1]);
                    }
                }

                input = Console.ReadLine();
            }
            
            if(parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
