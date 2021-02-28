namespace UMS.Services.Data.Models.CoursesParametersModels
{
    using Common.Mapping;
    using UMS.Data.Models;
    using Web.ViewModels.Courses;

    public class CourseEditParametersModel : CourseBaseParametersModel, IMapFrom<EditCourseInputForm>
    {
        public int Id { get; set; }
    }
}
