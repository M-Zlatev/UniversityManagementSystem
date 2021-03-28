namespace UMS.Web.ViewModels.Courses
{
    using Common.Mapping;
    using Data.Models.Courses;

    public class CourseListingViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
