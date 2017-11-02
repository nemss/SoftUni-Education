namespace SimpleMvc.App.Controllers
{
    using Framework.Contracts;
    using Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}