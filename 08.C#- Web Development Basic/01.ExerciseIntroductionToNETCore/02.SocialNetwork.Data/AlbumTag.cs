namespace _02.SocialNetwork.Data
{
    using __02.SocialNetwork.Data;

    public class AlbumTag
    {
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
