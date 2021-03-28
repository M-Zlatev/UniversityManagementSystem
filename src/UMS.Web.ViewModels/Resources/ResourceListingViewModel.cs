namespace UMS.Web.ViewModels.Resources
{
    using UMS.Data.Common.Enumerations;

    using UMS.Common.Mapping;
    using UMS.Data.Models.Resources;

    public class ResourceListingViewModel : IMapFrom<Resource>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}
