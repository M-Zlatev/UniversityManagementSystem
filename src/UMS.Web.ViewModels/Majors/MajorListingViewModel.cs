namespace UMS.Web.ViewModels
{
    using Data.Models.Majors;
    using Services.Mapping.Contracts;

    public class MajorListingViewModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
