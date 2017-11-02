namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using Utilities;

    public class AddTownCommand
    {
        //<AddTown> TownName CountryName
        //AddTown Plovdiv Bulgaria
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string townName = inputArgs[0];
            string countryName = inputArgs[1];

            AuthenticationManager.Authorize();

            if(CommandHelper.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            User currentUser = AuthenticationManager.GetCurrentUser();

            if(currentUser.Role == Role.Admin)
            {
                AddTown(townName, countryName);
                return $"Successfully add town {townName}";
            }
            else
            {
                return $"You have no rights";
            }
        }

        private void AddTown(string townName, string countryName)
        {
            using (LibraryContext context = new LibraryContext())
            {
                Town town = new Town()
                {
                    Name = townName,
                    Country = countryName
                };

                context.Towns.Add(town);
                context.SaveChanges();
            }
        }
    }
}
