namespace UMS.Web.ViewModels.Students
{
    using System.Collections.Generic;

    using Common.Mapping;
    using Data.Models;

    public class EditStudentInputForm : StudentBaseForm, IMapFrom<Student>
    {
        public int Id { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
