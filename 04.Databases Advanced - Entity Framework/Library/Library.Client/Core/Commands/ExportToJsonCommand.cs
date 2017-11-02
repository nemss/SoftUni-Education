namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using Utilities;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.IO;

    public class ExportToJsonCommand
    { 
        //<ExportToJson> <property> <where to save file>
        //ExportToJson   Users 
        //ExportToJson   UsersWithTheirBooks
        //ExportToJson   BooksWithTheirAuthor  
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string propType = inputArgs[0];
            string pathToFile = inputArgs[1];

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            if(currentUser.Role == Role.Admin)
            {
                if (propType == "Users")
                {
                    using (LibraryContext context = new LibraryContext())
                    {
                        var allUsers = context.Users
                            .Select(u => new
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                RegisteredOn = u.RegisteredOn,
                                LastTimeLoggedIn = u.LastTimeLoggedIn,
                                BookRead = u.Books.Count(),
                                BirtDate = u.BirthDate
                            })
                            .ToList();

                        ExportToJson(allUsers, pathToFile);
                    }
                }
                else if(propType == "UsersWithBooks")
                {
                    using (LibraryContext context = new LibraryContext())
                    {
                        var allUsersWithTheirBooks = context.Users
                            .Select(u => new
                            {
                                FirtName = u.FirstName,
                                LastName = u.LastName,
                                Books = u.Books.Select(b => new
                                {
                                    BookName = b.Title,
                                })
                            })
                            .ToList();

                        ExportToJson(allUsersWithTheirBooks, pathToFile);

                    }
                }
                else if(propType == "BooksWithAuthor")
                {
                    using (LibraryContext context = new LibraryContext())
                    {
                        var allBooks = context.Authors
                            .Select(a => new
                            {
                                AuthorName = a.FirstName + " " + a.LastName, 
                                Books = a.Books.Select(b => new
                                {
                                    BookName = b.Title
                                })
                            })
                            .ToList();

                        ExportToJson(allBooks, pathToFile);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid property!");
                }
            }
            else
            {
                return "You have no rights!";
            }
            return null;
        }

        private static void ExportToJson<TEntity>(TEntity entity, string path)
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
