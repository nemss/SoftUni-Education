namespace _1.CodeFirstStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum ResourceType
    {
        video,
        presentation,
        documentl,
        other
    }

    public class Resource
    {
        public Resource()
        {
            this.Licences = new HashSet<Licence>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Licence> Licences { get; set;}
    }
}
