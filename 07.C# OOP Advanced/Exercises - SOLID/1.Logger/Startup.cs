namespace _1.Logger
{
    using _1.Logger.Core;

    internal class Startup
    {
        private static void Main(string[] args)
        {
            var controller = new Controller();
            controller.Run();
        }
    }
}