namespace Library.Client.Core.Commands
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Utilities;

    public class AddBookCommand
    {
        //<AddBook> TitleBook FirstNameAuthor LastNameAuthor Genre
        public string Execute(string[] inputArgs)
        {
            //Check.CheckLength(3, inputArgs);
            string bookTitle = string.Empty;
            string AutorFirstName = string.Empty;
            string AuthorLastName = string.Empty;
            string genre = string.Empty;

            #region CheckLegthTitle
            if (inputArgs.Length == 4)
            {
                bookTitle = inputArgs[0];
                AutorFirstName = inputArgs[1];
                AuthorLastName = inputArgs[2];
                genre = inputArgs[3];
            }
            else if (inputArgs.Length == 5)
            {
                bookTitle = string.Concat(inputArgs[0], " ", inputArgs[1]);
                AutorFirstName = inputArgs[2];
                AuthorLastName = inputArgs[3];
                genre = inputArgs[4];
            }
            else if (inputArgs.Length == 6)
            {
                bookTitle = string.Concat(inputArgs[0], " ", inputArgs[1], " ", inputArgs[2]);
                AutorFirstName = inputArgs[3];
                AuthorLastName = inputArgs[4];
                genre = inputArgs[5];
            }
            else if (inputArgs.Length == 7)
            {
                bookTitle = string.Concat(inputArgs[0], " ", inputArgs[1], " ", inputArgs[2], " ", inputArgs[3]);
                AutorFirstName = inputArgs[4];
                AuthorLastName = inputArgs[5];
                genre = inputArgs[6];
            }
            #endregion

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();
            bool IsExistingBook = currentUser.Books.Any(b => b.Title == bookTitle);
            if(IsExistingBook)
            {
                throw new ArgumentException(Constants.ErrorMessages.BookExists, bookTitle);
            }
            LibraryContext context = new LibraryContext();
            //User user = context.Users.SingleOrDefault(u => u.Id == currentUser.Id);
            //List<User> listUser = new List<User>();
            //listUser.Add(user);
            

            AddBook(currentUser, bookTitle, AutorFirstName, AuthorLastName, genre);

            return $"Successfull add book {bookTitle}";
        }

        private void AddBook(User cuurrentUser, string bookTitle, string autorFirstName, string authorLastName, string genre)
        {
            LibraryContext context = new LibraryContext();
            Author author = new Author();
            Genre gnr = new Genre();
            Book b = new Book();

            if (CommandHelper.IsAuthorExisting(autorFirstName, authorLastName))
            {
                author = context.Authors.FirstOrDefault(a => a.FirstName == autorFirstName && a.LastName == authorLastName);
            }
            else
            {
                author.FirstName = autorFirstName;
                author.LastName = authorLastName;
            }

            if (CommandHelper.IsGenreExisting(genre))
            {
                gnr = context.Genres.FirstOrDefault(ge => ge.Name == genre);
            }
            else
            {
                gnr.Name = genre;
            }
           
            if(CommandHelper.IsBookExisting(bookTitle))
            {
                b = context.Books.FirstOrDefault(book => book.Title == bookTitle);
            }
            else
            {
                b.Title = bookTitle;
                b.Author = author;
                b.Genre = gnr;
                
            }

            User user = context.Users.SingleOrDefault(u => u.Id == cuurrentUser.Id);
            user.Books.Add(b);
            context.SaveChanges();

        }
    }
}
