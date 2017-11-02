namespace PhotographerSystem.Models
{
    using Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
