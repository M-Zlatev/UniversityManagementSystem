namespace UMS.Web.ViewModels.Majors
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class CreateMajorInputForm : MajorBaseForm
    {
        public int UserId { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DepartmentItems { get; set; }
    }
}
