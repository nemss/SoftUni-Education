namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;

    public class AccountController : BaseController
    {
        public IHttpResponse Register() => this.FileViewResponse(@"account\register");

    }
}
