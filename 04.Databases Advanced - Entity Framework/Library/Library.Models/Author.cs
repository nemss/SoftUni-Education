using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

  
namespace Library.Models
{
    public class Author
    {

        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
