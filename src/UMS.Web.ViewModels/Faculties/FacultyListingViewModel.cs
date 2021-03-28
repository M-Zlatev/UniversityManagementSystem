namespace UMS.Web.ViewModels
{
    using UMS.Common.Mapping;
    using UMS.Data.Models.Faculties;

    public class FacultyListingViewModel : IMapFrom<Faculty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
