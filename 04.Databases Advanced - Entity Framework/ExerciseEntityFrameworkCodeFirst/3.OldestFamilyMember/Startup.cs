namespace _3.OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main(string[] args)
        {
            int member = int.Parse(Console.ReadLine());

            Family parvanovi = new Family();

            for (int i = 0; i < member; i++)
            {
                string[] informationOboutFamily = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (informationOboutFamily.Length == 2)
                {
                    string firstName = informationOboutFamily[0];
                    int age = int.Parse(informationOboutFamily[1]);
                    parvanovi.AddMemer(new Person(firstName, age));
                }
                else if (informationOboutFamily.Length == 1) 
                {
                    string firstName = informationOboutFamily[0];
                    parvanovi.AddMemer(new Person(firstName));
                }
            }

            Console.WriteLine($"{parvanovi.GetOldestPerson().Name } - {parvanovi.GetOldestPerson().Age}");
        }
    }
}
