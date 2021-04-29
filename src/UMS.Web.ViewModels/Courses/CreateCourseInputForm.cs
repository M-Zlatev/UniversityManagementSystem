namespace UMS.Web.ViewModels.Courses
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class CreateCourseInputForm : CourseBaseForm
    {
        public int UserId { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
