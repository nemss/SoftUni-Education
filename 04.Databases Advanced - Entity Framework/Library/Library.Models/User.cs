namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Male,
        Female
    }
    public enum Role
    {
        Admin,
        User

    }
    public class User
    {
        public User()
        {
            this.Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? BornTownId { get; set; }
        public virtual Town BornTown { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public DateTime? LastTimeLoggedIn { get; set; }
        public Gender Genre { get; set; }
        public Role Role { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
