namespace LearningSystem.Data.Models
{
    using Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleTitleMinLenght)]
        [MaxLength(DataConstants.ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataConstants.ArticleContentMaxLenght)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}