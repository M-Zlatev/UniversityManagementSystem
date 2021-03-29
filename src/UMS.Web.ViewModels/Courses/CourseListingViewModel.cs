namespace UMS.Web.ViewModels.Courses
{
    using Data.Models.Courses;
    using Services.Mapping.Contracts;

    public class CourseListingViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
