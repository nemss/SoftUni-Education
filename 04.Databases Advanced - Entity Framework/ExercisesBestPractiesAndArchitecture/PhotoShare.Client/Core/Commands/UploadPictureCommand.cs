namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumTitle = data[0];
            string pictureTitle = data[1];
            string picturePath = data[2];

            if(!IsAlbumExisting(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} not found!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumTitle);
                Picture picture = new Picture()
                {
                    Path = picturePath,
                    Title = pictureTitle,
                };

                album.Pictures.Add(picture);
                context.SaveChanges();
            }
          
            return $"Picture {pictureTitle} added to {albumTitle}";
        }

        public bool IsAlbumExisting(string albumTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumTitle);
            }
        }
        public Album GetAlbumByAlbumName(string albumTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.SingleOrDefault(a => a.Name == albumTitle);
            }
        }
    }
}
