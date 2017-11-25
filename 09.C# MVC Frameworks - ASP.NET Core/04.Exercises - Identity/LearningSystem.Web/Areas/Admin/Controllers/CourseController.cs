namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CourseController : AdminBaseController
    {
        public IActionResult Create() => View();
    }
}