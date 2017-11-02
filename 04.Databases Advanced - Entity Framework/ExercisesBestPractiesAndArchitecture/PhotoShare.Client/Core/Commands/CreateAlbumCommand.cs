namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;
    using Utilities;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string backgroundColor = data[2];
            string[] tags = data.Skip(3).Select(t => TagUtilities.ValidateOrTransform(t)).ToArray();


            User user = GetUserByUserName(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            Color color;
            bool isColorValid = Enum.TryParse(backgroundColor, out color);

            if(!isColorValid)
            {
                throw new ArgumentException($"Color {color} not found!");
            }

            if(tags.Any(t => !IsTagExisting(t)))
            {
                throw new ArgumentException("Invalid tags!");
            }

            if(IsAlbumExisting(albumTitle))
            {
                throw new ArgumentException($"Albulm {albumTitle} exist!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = new Album();
                album.Name = albumTitle;
                album.BackgroundColor = color;
                album.Tags = context.Tags.Where(t => tags.Contains(t.Name)).ToList();

                User owner = context.Users.SingleOrDefault(u => u.Username == username);

                if(owner != null)
                {
                    AlbumRole albumRole = new AlbumRole();
                    albumRole.User = owner;
                    albumRole.Album = album;
                    albumRole.Role = Role.Owner;
                    album.AlbumRoles.Add(albumRole);

                    context.Albums.Add(album);
                    context.SaveChanges();
                }
            }

                return $"Albulm {albumTitle} successfully created!";
        }

        public bool IsAlbumExisting(string albumName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumName);
            }
        }
        public bool IsTagExisting(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }
        private User GetUserByUserName(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

    }
}
