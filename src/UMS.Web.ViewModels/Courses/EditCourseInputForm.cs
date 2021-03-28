namespace UMS.Web.ViewModels.Courses
{
    using Common.Mapping;
    using Data.Models.Courses;

    public class EditCourseInputForm : CourseBaseForm, IMapFrom<Course>
    {
        public int Id { get; set; }
    }
}
