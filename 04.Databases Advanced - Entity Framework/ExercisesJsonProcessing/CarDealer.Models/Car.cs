namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Car
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        
    }
}
