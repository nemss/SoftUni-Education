namespace BookShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookTitleMinLenght)]
        [MaxLength(BookTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }
    }
}
