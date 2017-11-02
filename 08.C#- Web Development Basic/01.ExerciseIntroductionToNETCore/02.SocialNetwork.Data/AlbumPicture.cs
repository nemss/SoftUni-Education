namespace _02.SocialNetwork.Data
{
    using __02.SocialNetwork.Data;

    public class AlbumPicture
    {
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int PictureId { get; set; }

        public Picture Picture { get; set; }
    }
}
