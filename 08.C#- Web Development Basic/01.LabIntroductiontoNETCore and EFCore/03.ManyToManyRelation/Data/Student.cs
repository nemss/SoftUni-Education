namespace _03.ManyToManyRelation.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();
    }
}