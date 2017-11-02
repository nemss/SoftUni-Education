using MyCoolWebServer.Infrastructure;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override string ApplicationDirectory => "GameStoreApplication";
    }
}
