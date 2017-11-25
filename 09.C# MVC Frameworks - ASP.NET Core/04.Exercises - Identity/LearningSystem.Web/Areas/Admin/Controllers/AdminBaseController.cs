namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRoleName)]
    public abstract class AdminBaseController : Controller
    {
    }
}