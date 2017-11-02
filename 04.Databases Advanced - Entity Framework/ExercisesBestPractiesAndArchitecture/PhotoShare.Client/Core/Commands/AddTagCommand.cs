namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;
    using Utilities;

    public class AddTagCommand
    {
        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tag = data[0].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {

                if(!context.Tags.Any(t => t.Name == tag))
                {
                    context.Tags.Add(new Tag
                    {
                        Name = tag
                    });

                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException($"Tag {tag} exists!");
                }
            }

            return tag + " was added successfully to database!";
        }
    }
}
