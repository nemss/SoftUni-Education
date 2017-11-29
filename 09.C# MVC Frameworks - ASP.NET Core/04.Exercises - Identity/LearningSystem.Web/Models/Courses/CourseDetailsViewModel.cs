namespace LearningSystem.Web.Models.Courses
{
    using Service.Models.Course;

    public class CourseDetailsViewModel
    {
        public CourseDetailsServiceModel Course { get; set; }

        public bool UserIsEnrolledCourse { get; set; }
    }
}
