namespace UMS.Web.ViewModels
{
    using Data.Models.Faculties;
    using Services.Mapping.Contracts;

    public class FacultyListingViewModel : IMapFrom<Faculty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
