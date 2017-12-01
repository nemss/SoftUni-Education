namespace LearningSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Service.Interfaces;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICourseService courses;
        private readonly IUserService users;

        public HomeController(ICourseService courses, IUserService users)
        {
            this.courses = courses;
            this.users = users;
        }

        public async Task<IActionResult> Index()
            => View(new SearchIndexViewModel
            {
                Courses = await this.courses.Active()
            });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchIndexViewModel
            {
                SearchText = model.SearchText
            };

            if (model.IsSearchingInCourses)
            {
                viewModel.Courses = await this.courses.FindAsync(model.SearchText);
            }

            if (model.IsSearchingInUsers)
            {
                viewModel.Users = await this.users.FindAsync(model.SearchText);
            }

            return View(viewModel);
        }

        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}