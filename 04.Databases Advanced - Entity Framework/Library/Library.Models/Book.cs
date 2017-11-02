namespace Library.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {

        public Book()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        public string Title { get; set; }

        [MinLength(10), MaxLength(200)]
        public string Description { get; set; }

        public DateTime? Released { get; set; }

        public float Raiting { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
