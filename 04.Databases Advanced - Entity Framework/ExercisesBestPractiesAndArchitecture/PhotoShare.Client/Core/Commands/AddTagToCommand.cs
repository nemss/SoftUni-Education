namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;
    using Utilities;

    public class AddTagToCommand
    {
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tagName = TagUtilities.ValidateOrTransform(data[1]);

            if(!(IsAlbumExisting(albumName) || IsTagExisting(tagName)))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

                album.Tags.Add(tag);
                context.SaveChanges();
                 
            }

                return $"Tag {tagName} added to {albumName}!";
        }

        public bool IsTagExisting(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }
        public bool IsAlbumExisting(string albumName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumName);
            }
        }
    }
}
