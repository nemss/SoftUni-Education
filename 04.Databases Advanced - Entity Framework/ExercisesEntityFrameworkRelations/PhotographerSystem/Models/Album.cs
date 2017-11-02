namespace PhotographerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Photographers = new HashSet<Photographer>();
        }

        [Key]
        public int  Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor  { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Photographer> Photographers { get; set; }


        public virtual ICollection<Tag> Tags { get; set; }
    }
}
