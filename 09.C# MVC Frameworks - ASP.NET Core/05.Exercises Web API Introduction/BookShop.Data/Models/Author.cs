namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenght)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}