namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using Utilities;

    public class ShowAllUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            if (currentUser.Role == Role.Admin)
            {
                ShollAllUsers(currentUser);
                return "";
            }
            else
            {
                return $"{currentUser.Username} no have rights!";
            }

        }

        private void ShollAllUsers(User currentUser)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var showAllUsers = context.Users
                    .Select(u => new
                    {
                        Username = u.Username,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        Role=u.Role
                    });

                Console.WriteLine(String.Format($"{"Username", -15} {"First Name",-17} {"Last Name",-17} {"Age",-18} {"Role",-15}"));
                Console.WriteLine(new string('-', 80));
                foreach (var user in showAllUsers)
                {
                    Console.WriteLine(String.Format($"{user.Username, -15} | {user.FirstName,-15} | {user.LastName,-15} | {user.Age,-15} | {user.Role,-15}"));

                }
            }
        }


    }
}
