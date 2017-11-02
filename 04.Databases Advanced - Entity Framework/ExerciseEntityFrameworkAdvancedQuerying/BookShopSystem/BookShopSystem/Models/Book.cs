namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }
    
    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }
    public class Book
    {
        public Book()
        {
            this.Categories = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(1),MaxLength(50)]
        public string Title { get; set; }

        [MinLength(1000)]
        public string Description { get; set; }

        public EditionType Type { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }

    }
}
