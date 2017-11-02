using Card_Problem.Core;

namespace Card_Problem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}