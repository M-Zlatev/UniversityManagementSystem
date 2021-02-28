namespace UMS.Web.ViewModels.Courses
{
    using Common.Mapping;
    using Data.Models;

    public class EditCourseInputForm : CourseBaseForm, IMapFrom<Course>
    {
        public int Id { get; set; }
    }
}
