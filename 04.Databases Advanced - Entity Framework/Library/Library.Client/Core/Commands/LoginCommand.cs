namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Utilities;

    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string username = inputArgs[0];
            string password = inputArgs[1];

            if(AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = this.GetByCredentials(username, password);

            if(user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            LibraryContext context = new LibraryContext();
            user.LastTimeLoggedIn = DateTime.Now;

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            return $"User {user.Username} successfully logged in!";
        }

        private User GetByCredentials(string username, string password)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }
    }
}
