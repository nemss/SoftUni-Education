namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Models;
    using System.Linq;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                if(context.Towns.Any(t => t.Name == townName))
                {
                    throw new ArgumentException($"Town {townName} already added!");
                }
                else
                {
                    context.Towns.Add(town);
                    context.SaveChanges();
                }

                return  $"{town.Name} was added successfully!";
            }
        }
    }
}
