namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Service;
    using Service.Blog.Models;

    public class ArticleListingViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.BlogArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1
            ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == TotalPages
            ? this.TotalPages : this.CurrentPage + 1;
    }
}
