namespace TeamBuilder.App.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using Utilities;

    public class DeleteUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            DeleteUser(currentUser);

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} was deleted successfully!";
        }

        private void DeleteUser(User currentUser)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                context.Users.SingleOrDefault(u => u.Id == currentUser.Id).IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}
