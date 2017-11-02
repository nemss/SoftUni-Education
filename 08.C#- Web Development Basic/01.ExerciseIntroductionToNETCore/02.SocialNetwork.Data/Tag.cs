using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _02.SocialNetwork.Data.Validations;

namespace _02.SocialNetwork.Data
{
    public class Tag
    {
        public int Id { set; get; }

        [Required]
        [Tag]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<AlbumTag> Albums { get; set; } = new List<AlbumTag>();

    }
}
