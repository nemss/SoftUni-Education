namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using Data.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PublishArticleFormModel
    {
        [Required]
        [MinLength(DataConstants.ArticleTitleMinLenght)]
        [MaxLength(DataConstants.ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataConstants.ArticleContentMaxLenght)]
        public string Content { get; set; }
    }
}
