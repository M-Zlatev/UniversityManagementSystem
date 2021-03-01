namespace UMS.Web.ViewModels.Students
{
    using System.Collections.Generic;

    public class CreateStudentInputForm : StudentBaseForm
    {
        public string UserId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
