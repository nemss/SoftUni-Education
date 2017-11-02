namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;

    public class ShareAlbumCommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            string albumId = data[0];
            string username = data[1];
            string permission = data[2];
            int id = int.Parse(albumId);

            Album album = GetAlbumNameByAlbumId(id);
            if(!IsAlbumExisting(id))
            {
                throw new ArgumentException($"Album {id} not found!");
            }

            if(!IsUsernameExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            Role role;
            bool isRoleValid = Enum.TryParse(permission, out role);

            if(!isRoleValid)
            {
                throw new ArgumentException("Permission must be either Owner or Viewer!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album albumName = context.Albums.SingleOrDefault(a => a.Id == id);
                User u = context.Users.SingleOrDefault(a => a.Username == username);
                AlbumRole albumRole = new AlbumRole();

                albumRole.Album = albumName;
                albumRole.User = u;
                albumRole.Role = role;
                albumName.AlbumRoles.Add(albumRole);

                context.SaveChanges();
                
            }

                return $"User {username} added to album {album.Name} ({permission})";
        }

        public bool IsUsernameExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }
        public bool IsAlbumExisting(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Id == albumId);
            }
        }
        public  Album GetAlbumNameByAlbumId(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
               return context.Albums.Find(albumId);
            }
        }
    }
}
