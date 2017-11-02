using System.Collections.Generic;
using __02.SocialNetwork.Data;

namespace _02.SocialNetwork.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using _02.SocialNetwork.Data.Validations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] ProfilePictire { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggetIn { get; set; }

        [Range(1, 120)]
        public int? Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<FriendShip> FromFriends { get; set; } = new List<FriendShip>();

        public ICollection<FriendShip> ToFriends { get; set; } = new List<FriendShip>();

        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
