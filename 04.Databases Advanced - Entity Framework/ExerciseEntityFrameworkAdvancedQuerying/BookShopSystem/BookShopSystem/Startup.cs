namespace BookShopSystem
{
    using EntityFramework.Extensions;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    class Startup
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();
            //context.Database.Initialize(true);

            //Exercise 1
            //BooksTitlesByAgeRestriction(context);

            //Exercise 2
            //GolgenBooks(context);

            //Exercise 3
            //BookByPrice(context);

            //Exercise 4
            //NotRealasedBooks(context);

            //Exercise 5 
            //BookTitlesByCategory(context);

            //Exercise 6
            //BooksRealeasedBeforeDate(context);

            //Exercise 7
            //AuthorsSearch(context);

            //Exercise 8
            //BookSearch(context);

            //Exercise 9
            //BookTitleSearch(context);

            //Exercise 10
            //CountBookCopies(context);

            //Exercise 11
            //TotalBookCopies(context);

            //Exercise 12 
            //FindProfit(context);

            //Exercise 13 
            //MostResentBooks(context);

            //Exercise 14
            //IncreaseBookCopies(context);

            //Exercise 15
            //RemoveBooks(context);

            //Exersice 16
            //StoreProcedure(context);


        }

        private static void StoreProcedure(BookShopContext context)
        {
            //CREATE PROCEDURE usp_GetBooksCountByAutorName(@firstName VARCHAR(MAX), @lastName VARCHAR(MAX))
            //AS
            //BEGIN
            //SELECT COUNT(*) FROM Books AS b
            //INNER JOIN Authors AS a
            //ON b.Author_Id = a.Id
            //WHERE a.FirstName = @firstName AND a.LastName = @lastName
            //END
            Console.WriteLine("Please enter the first and last name: ");
            string[] names = Console.ReadLine().Split(' ');

            SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            firstName.Value = names[0];
            lastName.Value = names[1];

            var count = context.Database.SqlQuery<int>("EXEC usp_GetBooksCountByAutorName @firstName, @lastName", firstName, lastName).First();

            Console.WriteLine($"{firstName.Value} {lastName.Value} has written {count} books");

        }

        private static void RemoveBooks(BookShopContext context)
        {
            var bookCount = context.Books.Where(c => c.Copies < 4200);

            Console.WriteLine($"{bookCount.Count()} books were deleted");
            context.Books.Delete(bookCount);
            context.SaveChanges();
        }

        private static void IncreaseBookCopies(BookShopContext context)
        {
            Console.Write($"Please enter release date: ");
            string date = Console.ReadLine();
            DateTime time = DateTime.ParseExact(date, "dd-MMM-yyyy", null);

            Console.Write($"Please enter number of copies: ");
            int numberOfCopies = int.Parse(Console.ReadLine());

            var count = context.Books.Count(b => b.ReleaseDate > time);
            Console.WriteLine($"{count} books are released after {date} so total of {count * numberOfCopies} book copies were added");

            var book = context.Books.Where(b => b.ReleaseDate > time);
            context.Books.Update(book, b => new Book() { Copies = b.Copies + numberOfCopies });
            context.SaveChanges();

            
        }

        private static void MostResentBooks(BookShopContext context)
        {
            var bookByCategory = context.Categories
                 .Where(c => c.Books.Sum(b => b.Id) > 35)
                 .OrderBy(c => c.Books.Count)
                 .Select(c => new
                 {
                     TotalBookCount = c.Books.Sum(b => b.Id),
                     CategoryName = c.Name,
                 });

            var books = context.Books
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Take(3)
                .Select(b => new
                {
                    BookName = b.Title,
                    BookRealeaseDay = b.ReleaseDate
                });

            foreach (var c in bookByCategory)
            {
                Console.WriteLine($"--{c.CategoryName}: {c.TotalBookCount} books.");

                foreach (var b in books)
                {
                    Console.WriteLine($"{b.BookName} ({b.BookRealeaseDay})");
                }
            }     

        }

        private static void FindProfit(BookShopContext context)
        {
            var profit = context.Categories
                .GroupBy(g => g.Name)
                .Select(s => new
                {
                    CategoryName = s.Key,
                    TotalProfit = s.Sum(p => p.Books.Sum(c => c.Price)) 
                })
                .OrderByDescending(p => p.TotalProfit)
                .OrderBy(p => p.CategoryName);

            foreach (var c in profit)
            {
                Console.WriteLine($"{c.CategoryName}");
            }

            //var findProfit = context.Categories
            //    .GroupBy(c => new
            //    {
            //        CategoryName = c.Name,
            //        Profit = c.Books.Sum(b => b.Price * b.Copies)
            //    })
            //    .OrderByDescending(cot => cot.Key.Profit)
            //    .ThenBy(cot => cot.Key.CategoryName);

            //foreach (var c in findProfit)
            //{
            //    Console.WriteLine($"{c.Key.CategoryName} - ${c.Key.Profit}");
            //}
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var totalCopies = context.Authors
                .GroupBy(a => new
                {
                    authorName = a.FirstName + " " + a.LastName,
                    copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Key.copies);

            foreach ( var a in totalCopies)
            {
                Console.WriteLine($"{a.Key.authorName} - {a.Key.copies}");
            }
                
        }

        private static void CountBookCopies(BookShopContext context)
        {
            Console.Write("Please enter the length of the title: ");
            int titleLength = int.Parse(Console.ReadLine());

            var countBook = context.Books
                .Where(b => b.Title.Length > titleLength);

            
                Console.WriteLine($"They are {countBook.Count()} books with longer title than {titleLength} symbols");
            
                
        }

        private static void BookTitleSearch(BookShopContext context)
        {
            Console.Write("Please enter a string: ");
            string search = Console.ReadLine();

            var bookTitlesSearch = context.Books
                .Where(b => b.Author.LastName.StartsWith(search))
                .OrderBy(b => b.Id)
                .Select(b => new
                {
                    bookTitle = b.Title,
                    bookAuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                });

            foreach (var b in bookTitlesSearch)
            {
                Console.WriteLine($"{b.bookTitle} ({b.bookAuthorFullName})");
            }
        }

        private static void BookSearch(BookShopContext context)
        {
            Console.WriteLine("Please enter a string: ");
            string search = Console.ReadLine();

            var booksSearch = context.Books
                .Where(b => b.Title.Contains(search))
                .Select(b => b.Title);

            foreach (var b in booksSearch)
            {
                Console.WriteLine($"{b}");
            }
        }

        private static void AuthorsSearch(BookShopContext context)
        {
            Console.Write("Please enter a string: ");

            string input = Console.ReadLine()
                .Trim()
                .ToLower();

            var authorsSeearch = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                });

            foreach (var a in authorsSeearch)
            {
                Console.WriteLine($"{a.FullName}");
            }
        }

        private static void BooksRealeasedBeforeDate(BookShopContext context)
        {
            Console.Write("Enter date: ");
            string inptut = Console.ReadLine()
                .Trim()
                .ToLower();
            DateTime time = DateTime.ParseExact(inptut, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < time)
                .Select(b => new
                {
                    bookTitle = b.Title,
                    bookType = b.Type,
                    bookPrice = b.Price
                }); ;

            foreach (var b in books)
            {
                Console.WriteLine($"{b.bookTitle} - {b.bookType} - {b.bookPrice}");
            }
        }

        private static void BookTitlesByCategory(BookShopContext context)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) 
                .ToList();

            foreach (var b in context.Books)
            {
                if (b.Categories.Any(c => input.Contains(c.Name.ToLower())))
                {
                    Console.WriteLine(b.Title);
                }
            }
        }

        private static void NotRealasedBooks(BookShopContext context)
        {
            Console.Write("Please enter a year: ");
            int year = int.Parse(Console.ReadLine());

            var notRealeasedBooks = context.Books
                 .Where(b => b.ReleaseDate.Value.Year != year)
                 .OrderBy(b => b.Id)
                 .Select(b => b.Title);

            foreach (var b in notRealeasedBooks)
            {
                Console.WriteLine($"{b}");
            }
        }

        private static void BookByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                 .Where(b => b.Price > 40 || b.Price < 5)
                 .OrderBy(b => b.Id)
                 .Select(b => new
                 {
                     BookName = b.Title,
                     BookPrice = b.Price,
                 });

            foreach (var b in booksByPrice)
            {
                Console.WriteLine($"{b.BookName} - {b.BookPrice}");
            }

        }

        private static void GolgenBooks(BookShopContext context)
        {
            string editionType = "Gold";
            var golgenBooks = context.Books
                .Where(b => b.Type == EditionType.Gold && b.Copies < 5000) // .Where(b => b.Type.ToString() == editionType && b.Copies < 5000)
                .Select(b => b.Title);

            foreach (var b in golgenBooks)
            {
                Console.WriteLine($"{b}");
            }
                
                
        }

        private static void BooksTitlesByAgeRestriction(BookShopContext context)
        {
            Console.Write("Age restriction - ");
            string input = Console.ReadLine().ToLower().Trim();
            var booksFromQuery = context.Books
                .Where(e => e.AgeRestriction.ToString() == input)
                .Select(e => e.Title);
            foreach (var book in booksFromQuery)
            {
                Console.WriteLine($"{book}");
            }
        }
    }
}
