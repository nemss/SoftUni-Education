namespace GameraBazaar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<Camera> Cameras { get; set; } = new List<Camera>();
    }
}
