namespace UMS.Web.ViewModels.Departments
{
    using System.Collections.Generic;

    public class CreateDepartmentInputForm : DepartmentBaseForm
    {
        public string UserId { get; set; }

        public int FacultyId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FacultyItems { get; set; }
    }
}
