namespace SimpleMvc.App
{
    using Data;
    using Framework;
    using Framework.Routers;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            var server = new WebServer.WebServer(1337, new ControllerRouter());

            var db = new SimpleMvcDbContext();

            db.Database.EnsureCreated();

            MvcEngine.Run(server);
        }
    }
}