namespace _6.BirthdayCelebrations.Models
{
    public class Robot : IInhabitant, IId
    {
        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; }
        public string Id { get; }
    }
}