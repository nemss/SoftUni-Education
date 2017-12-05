namespace BookShop.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(AuthorNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenght)]
        public string LastName { get; set; }
    }
}