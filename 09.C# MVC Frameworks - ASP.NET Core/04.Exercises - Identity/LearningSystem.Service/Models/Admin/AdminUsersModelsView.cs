namespace LearningSystem.Service.Models.Admin
{
    using Data.Constants;
    using System.ComponentModel.DataAnnotations;

    public class AdminUsersModelsView
    {
        public string Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLenght)]
        [MaxLength(DataConstants.NameMaxLenght)]
        public string Username { get; set; }

        public string Email { get; set; }
    }
}