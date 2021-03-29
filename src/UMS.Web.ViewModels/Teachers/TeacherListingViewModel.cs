namespace UMS.Web.ViewModels.Teachers
{
    using Data.Models.Teachers;
    using Services.Mapping.Contracts;

    public class TeacherListingViewModel : IMapFrom<Teacher>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
