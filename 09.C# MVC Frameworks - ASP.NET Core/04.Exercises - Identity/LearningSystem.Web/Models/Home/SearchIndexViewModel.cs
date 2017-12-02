namespace LearningSystem.Web.Models.Home
{
    using Service.Models.Course;
    using Service.Models.Users;
    using System.Collections.Generic;

    public class SearchIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }

        public IEnumerable<UserListingServiceModel> Users { get; set; }

        public string SearchText { get; set; }
    }
}
