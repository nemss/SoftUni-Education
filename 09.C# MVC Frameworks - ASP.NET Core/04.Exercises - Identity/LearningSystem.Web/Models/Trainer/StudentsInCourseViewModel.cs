namespace LearningSystem.Web.Models.Trainer
{
    using Service.Models.Course;
    using Service.Models.Trainers;
    using System.Collections.Generic;

    public class StudentsInCourseViewModel
    {
        public IEnumerable<StudentInCourseServiceModel> Students { get; set; }

        public CourseListingServiceModel Course { get; set; }
    }
}
