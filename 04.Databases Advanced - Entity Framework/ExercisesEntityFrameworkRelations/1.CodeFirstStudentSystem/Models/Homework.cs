namespace _1.CodeFirstStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public enum ContentType
    {
        application,
        pdf,
        zip
    }

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
