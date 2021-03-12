namespace UMS.Web.ViewModels.Students
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class CreateStudentInputForm : StudentBaseForm
    {
        public string UserId { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
