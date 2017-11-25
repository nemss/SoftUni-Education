namespace LearningSystem.Data.Models
{
    using Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLenght)]
        [MaxLength(DataConstants.NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLenght)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        public User Trainer { get; set; }

        public ICollection<StudentCourse> Students { get; set; } = new List<StudentCourse>();
    }
}