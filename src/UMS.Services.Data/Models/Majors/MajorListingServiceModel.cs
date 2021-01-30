namespace UMS.Services.Data.Models.Majors
{
    using UMS.Data.Models;
    using Mapping;

    public class MajorListingServiceModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        public string MajorName { get; set; }

        public string Description { get; set; }
    }
}
