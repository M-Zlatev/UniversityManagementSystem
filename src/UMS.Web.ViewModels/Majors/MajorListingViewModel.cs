namespace UMS.Web.ViewModels
{
    using Common.Mapping;
    using Data.Models.Majors;

    public class MajorListingViewModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
