namespace PhotographerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Photographer
    {
        public Photographer()
        {
            this.Albulms = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Album> Albulms { get; set; }
    }
}
