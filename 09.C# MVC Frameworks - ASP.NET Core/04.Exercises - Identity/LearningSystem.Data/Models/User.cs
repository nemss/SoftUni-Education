namespace LearningSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public ICollection<Course> Trainigs { get; set; } = new List<Course>();

        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
