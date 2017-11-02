namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Comman { get; set; }
    }
}
