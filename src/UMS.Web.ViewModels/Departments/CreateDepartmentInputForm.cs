namespace UMS.Web.ViewModels.Departments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateDepartmentInputForm : DepartmentBaseForm
    {
        public int UserId { get; set; }

        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FacultyItems { get; set; }
    }
}
