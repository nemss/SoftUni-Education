namespace BookShop.Api.Models.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class CreateCategoryRequestModel
    {
        [Required]
        [MaxLength(CategoryMaxLenght)]
        public string Name { get; set; }
    }
}