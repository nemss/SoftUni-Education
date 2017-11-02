using Hell.Factories;

public class StartUp
{
    public static void Main()
    {
        ItemFactory itemFactory = new ItemFactory();

        IRecipeFactory recipeFactory = new RecipeFactory();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IHeroManager heroManager = new HeroManager(itemFactory, recipeFactory);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(heroManager);

        Engine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}