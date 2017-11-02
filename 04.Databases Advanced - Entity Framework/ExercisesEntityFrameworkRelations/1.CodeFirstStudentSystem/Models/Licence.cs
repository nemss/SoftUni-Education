namespace _1.CodeFirstStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Licence
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
