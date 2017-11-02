namespace _11.GetUsersByEmailProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            UserContext context = new UserContext();
            string inptut = Console.ReadLine();

            var userEmail = context.Users
                .Where(p => p.Email.Substring(p.Email.IndexOf("@")+1, inptut.Length) == inptut)
                .Select(p => new { p.UserName, p.Email });

            if (userEmail.Count() > 0)
            {
                foreach (var ue in userEmail)
                {
                    Console.WriteLine($"{ue.UserName} - {ue.Email}");
                }
            }
            else
            {
                Console.WriteLine($"No users found with email domein {inptut}");
            }

        }
    }
}
