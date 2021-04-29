namespace UMS.Services.Data.Models.CoursesParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Courses;

    public class CourseCreateParametersModel : CourseBaseParametersModel, IMapFrom<CreateCourseInputForm>
    {
        public int UserId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
