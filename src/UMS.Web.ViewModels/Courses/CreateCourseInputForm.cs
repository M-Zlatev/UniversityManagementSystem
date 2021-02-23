namespace UMS.Web.ViewModels.Courses
{
    using System.Collections.Generic;

    public class CreateCourseInputForm : CourseBaseForm
    {
        public string UserId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
