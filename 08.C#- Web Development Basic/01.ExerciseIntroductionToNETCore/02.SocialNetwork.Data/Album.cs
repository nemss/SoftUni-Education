using System.Collections.Generic;
using _02.SocialNetwork.Data;

namespace __02.SocialNetwork.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Background { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<AlbumPicture> Pictures { get; set; } = new List<AlbumPicture>();

        public ICollection<AlbumTag> Tags { get; set; } = new List<AlbumTag>();
    }
}
