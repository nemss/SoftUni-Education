namespace PhotographerSystem
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            PhotographerContext context = new PhotographerContext();

            //Console.WriteLine(context.Photographers.Count());

            Tag tag = new Tag() { Name = "pesho" };
            try
            {
            context.Tags.Add(tag);
            context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                tag.Name = TagTransformer.Transform(tag.Name);
                context.SaveChanges();
                Console.WriteLine($"{tag.Name} was added to database.");
            }
        }
    }
}
