namespace _02.OneToManyRelation
{
    using _02.OneToManyRelation.Data;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var db = new AppDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            using (db)
            {
                var department = new Department { Name = "C#" };

                for (int i = 0; i < 10; i++)
                {
                    department.Employees.Add(new Employee { Name = $"Employee {i}" });
                }

                db.Add(department);
                db.SaveChanges();
            }
        }
    }
}