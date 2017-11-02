namespace _12.RemoveInactiveUsers
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
            Console.WriteLine("Format yyyy-mm-dd");
            string[] input = Console.ReadLine().Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);

            DateTime logDate = new DateTime(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

            List<User> users = context.Users.Where(user => user.LastTimeLoggedIn < logDate && !user.IsDeleted).ToList();
            foreach (User user in users)
            {
                user.IsDeleted = true;
            }
            if (users.Count == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine($"{users.Count} user has been deleted");
            }

            context.SaveChanges();
        }
    }
}
