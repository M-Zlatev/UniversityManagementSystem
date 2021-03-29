namespace UMS.Web.ViewModels.Resources
{
    using Data.Common.Enumerations;
    using Data.Models.Resources;
    using Services.Mapping.Contracts;

    public class ResourceListingViewModel : IMapFrom<Resource>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}
