namespace TeamBuilder.App
{
    using Core;
    using Data;
    using System;
    class Application
    {
        static void Main(string[] args)
        {
            TeamBuilderContext context = new TeamBuilderContext();
            //context.Database.Initialize(true);

            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
