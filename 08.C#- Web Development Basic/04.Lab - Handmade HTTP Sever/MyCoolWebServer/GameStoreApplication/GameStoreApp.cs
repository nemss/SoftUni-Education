namespace MyCoolWebServer.GameStoreApplication
{
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Controllers;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPath.Add("/account/register");

            appRouteConfig
                .Get("/account/register",
                    req => new AccountController().Register());
        }
    }
}
