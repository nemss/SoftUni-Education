namespace Library.Client.Core
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Utilities;

    public class ModifyUserCommand
    {
        //ModifyUser <property> <new value>
        //ModifyUser Password <newPassword>
        //ModifyUser BornTown <newBornTown>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string propType = inputArgs[0];
            string value = inputArgs[1];

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();
            LibraryContext context = new LibraryContext();
            User user = context.Users.SingleOrDefault(u => u.Id == currentUser.Id);

            Town t = new Town();

            if (propType == "Password")
            {
                if (!value.Any(char.IsDigit) || !propType.Any(char.IsUpper))
                {
                    throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, value));
                }

                user.Password = value;
            }
            else if(propType == "BornTown")
            {
                if(CommandHelper.IsTownExisting(value))
                {
                    t = context.Towns.FirstOrDefault(ta => ta.Name == value);
                }

                user.BornTown = t;
            }
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            return $"User {currentUser.Username} {propType} is {value}";
        }
    }
}
