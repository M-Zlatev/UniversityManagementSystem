namespace UMS.Web.ViewModels.Administration
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class EditRoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
