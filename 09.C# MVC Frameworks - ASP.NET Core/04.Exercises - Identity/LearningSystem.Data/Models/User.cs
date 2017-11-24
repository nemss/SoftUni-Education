namespace LearningSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLenght)]
        [MaxLength(DataConstants.UserNameMaxLengh)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public ICollection<Course> Trainigs { get; set; } = new List<Course>();

        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
