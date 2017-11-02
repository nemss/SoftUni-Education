namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Utilities;

    public class ChangeRoleCommand
    {
        //<ChangeRole> username role
        //ChangeRole nems Admin
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string username = inputArgs[0];

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();
            if (currentUser.Role == Role.Admin)
            {
                if (!CommandHelper.IsUserExisting(username))
                {
                    throw new ArgumentException("Username does not exist!");
                }

                Role role;
                bool isRoleValid = Enum.TryParse(inputArgs[1], out role);

                if (!isRoleValid)
                {
                    throw new ArgumentException(Constants.ErrorMessages.RoleNotValid);
                }

                ChangeRole(role, username);

                return $"Successufully change role!";
            }
            else
            {
                return $"You have no rights";
            }
        }

        private void ChangeRole(Role role, string username)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user.Role == role)
                {
                    throw new ArgumentException(String.Format(Constants.ErrorMessages.RoleIsTheSame, role));
                }

                user.Role = role;

                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
