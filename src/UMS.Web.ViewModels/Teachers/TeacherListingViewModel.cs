namespace UMS.Web.ViewModels.Teachers
{
    using Common.Mapping;
    using Data.Models.Teachers;

    public class TeacherListingViewModel : IMapFrom<Teacher>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
