namespace UMS.Web.ViewModels
{
    using UMS.Data.Models;
    using Services.Mapping;

    public class FacultyListingServiceModel : IMapFrom<Faculty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
