namespace CarDealer.App.Models.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CarFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(0, long.MaxValue, ErrorMessage = "{2} must be positive number.")]
        public long TravelledDistance { get; set; }

        public IEnumerable<int> SelectParts { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<SelectListItem> AllParts { get; set; }
    }
}
