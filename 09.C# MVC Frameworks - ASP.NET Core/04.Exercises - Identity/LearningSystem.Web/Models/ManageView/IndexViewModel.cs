namespace LearningSystem.Web.Models.ManageView
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Constants;

    public class IndexViewModel
    {
        public string Username { get; set; }

        [MinLength(DataConstants.NameMinLenght)]
        [MaxLength(DataConstants.NameMaxLenght)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}