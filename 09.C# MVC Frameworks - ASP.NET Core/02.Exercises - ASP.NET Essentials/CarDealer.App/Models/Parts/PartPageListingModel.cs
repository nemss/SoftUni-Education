namespace CarDealer.App.Models.Parts
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Services.Models.Parts;

    public class PartPageListingModel
    {
        public IEnumerable<PartListingModel> Parts { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1 
            ? 1 
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ?
            this.TotalPages 
            : this.CurrentPage + 1;
    }
}
