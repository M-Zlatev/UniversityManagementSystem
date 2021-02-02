namespace UMS.Web.ViewModels
{
    using Common.Mapping;
    using Data.Models;

    public class MajorListingViewModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        public string MajorName { get; set; }

        public string Description { get; set; }
    }
}
