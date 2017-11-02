namespace Library.Client.Utilities
{
    using Data;
    using System;
    using System.Linq;

    public class CommandHelper
    {
        public static bool IsUserExisting(string username)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Users.Any(u => u.Username == username && u.IsDeleted == false);
            }
        }

        public static bool IsBookExisting(string bookName)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.Any(b => b.Title == bookName);
            }
        }

        public static bool IsGenreExisting(string genre)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Genres.Any(g => g.Name == genre);
            }
        }

        public static bool IsAuthorExisting(string firstName, string lastName)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName);
            }
        }

        public static bool IsTownExisting(string townName)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

    }
}
