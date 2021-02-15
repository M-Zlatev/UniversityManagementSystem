namespace UMS.Web.ViewModels.Resources
{
    using AutoMapper;

    using Common.Mapping;
    using Data.Common.Enumerations;
    using Data.Models;

    public class ResourceGetDetailsByIdViewModel : IMapFrom<Resource>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }

        public string BelongsToCourse { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Resource, ResourceGetDetailsByIdViewModel>()
                .ForMember(r => r.BelongsToCourse, cfg => cfg.MapFrom(c => c.Course.Name));
        }
    }
}
