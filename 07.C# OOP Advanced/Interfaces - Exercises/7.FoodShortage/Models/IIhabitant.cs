namespace _7.FoodShortage.Models
{
    public interface IIhabitant : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}