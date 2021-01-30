namespace UMS.Services.Data.Models.Faculties
{
    using UMS.Data.Models;
    using Mapping;

    public class FacultyListingServiceModel : IMapFrom<Faculty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
