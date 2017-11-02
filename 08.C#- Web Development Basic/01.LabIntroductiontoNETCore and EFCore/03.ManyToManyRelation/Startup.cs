namespace _03.ManyToManyRelation
{
    public class Startup
    {
        public static void Main()
        {
            var db = new MyDbContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}