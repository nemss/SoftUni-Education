namespace LearningSystem.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Courses")]
        public bool IsSearchingInCourses { get; set; }

        [Display(Name = "Search In Users")]
        public bool IsSearchingInUsers { get; set; }
    }
}
