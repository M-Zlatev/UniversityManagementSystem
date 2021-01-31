namespace UMS.Web.ViewModels
{
    using UMS.Data.Models;
    using Services.Mapping;

    public class MajorListingServiceModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        public string MajorName { get; set; }

        public string Description { get; set; }
    }
}
