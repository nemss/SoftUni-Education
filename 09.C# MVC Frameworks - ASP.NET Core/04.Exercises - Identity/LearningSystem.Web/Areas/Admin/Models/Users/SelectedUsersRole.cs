namespace LearningSystem.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Service.Models.Admin;
    using System.Collections.Generic;

    public class SelectedUsersRole
    {
        public IEnumerable<AdminUsersModelsView> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}