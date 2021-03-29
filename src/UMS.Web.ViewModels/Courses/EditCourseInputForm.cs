namespace UMS.Web.ViewModels.Courses
{
    using Data.Models.Courses;
    using Services.Mapping.Contracts;

    public class EditCourseInputForm : CourseBaseForm, IMapFrom<Course>
    {
        public int Id { get; set; }
    }
}
