﻿namespace MyCoolWebServer.GameStoreApplication.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<UserGame> Games { get; set; } = new List<UserGame>();
    }
}
