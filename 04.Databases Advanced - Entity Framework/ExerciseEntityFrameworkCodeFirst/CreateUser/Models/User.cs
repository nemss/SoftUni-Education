namespace CreateUser.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;

    public  class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4), MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [MaxLength(1024 * 1024)]
        public byte[]  ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn  { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted  { get; set; }
    }
}
