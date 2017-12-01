namespace LearningSystem.Service.Interfaces
{
    using Models.Course;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> Active();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string search);

        Task<TModel> ByIdAsync<TModel>(int id) where  TModel : class;

        Task<bool> SignUpStudentAsync(int courseId, string studentId);

        Task<bool> SignOutStudentAsync(int courseId, string studentId);

        Task<bool> StudentIsEnrolledCourseAsync(int courseId, string studentId);
    }
}
