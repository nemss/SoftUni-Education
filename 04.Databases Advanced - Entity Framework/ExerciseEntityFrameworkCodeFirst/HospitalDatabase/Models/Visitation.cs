namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public Patient Pation { get; set; }

    }
}
