namespace UMS.Web.ViewModels.Majors
{
    using System.Collections.Generic;

    public class CreateMajorInputForm : MajorBaseForm
    {
        public string UserId { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DepartmentItems { get; set; }
    }
}
