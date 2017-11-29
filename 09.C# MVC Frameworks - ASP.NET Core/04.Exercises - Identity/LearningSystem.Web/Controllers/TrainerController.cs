namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Trainer;
    using Service.Interfaces;
    using System.Threading.Tasks;
    using Service.Models.Course;

    [Authorize(Roles = WebConstants.TrainerRoleName)]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainers;
        private readonly UserManager<User> userManager;
        private readonly ICourseService courses;

        public TrainerController(
            ITrainerService trainers,
            UserManager<User> userManager,
            ICourseService courses)
        {
            this.trainers = trainers;
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task<IActionResult> Courses()
        {
            var userId = this.userManager.GetUserId(User);
            var courses = await this.trainers.CoursesAsync(userId);

            return View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);
            if (!await this.trainers.IsTrainer(id, userId))
            {
                return NotFound();
            }

            return View(new StudentsInCourseViewModel
            {
                Students = await this.trainers.StudentsInCourseAsync(id),
                Course = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();

            }

            var userId = this.userManager.GetUserId(User);
            if (!await this.trainers.IsTrainer(id, userId))
            {
                return BadRequest();
            }

            var success = await this.trainers.AddGrade(id, studentId, grade);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Students), new {id});
        }
    }
}
