namespace UMS.Services.Data.Models.CoursesParametersModels
{
    using System.Collections.Generic;

    using Common.Mapping;
    using Web.ViewModels.Courses;

    public class CourseCreateParametersModel : CourseBaseParametersModel, IMapFrom<CreateCourseInputForm>
    {
        public string UserId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
