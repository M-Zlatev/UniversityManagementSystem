namespace UMS.Web.ViewModels
{
    using AutoMapper;

    using UMS.Data.Models;
    using Services.Mapping;

    public class DepartmentListingServiceModel : IMapFrom<Department>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BelongsToFaculty { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Department, DepartmentListingServiceModel>()
                .ForMember(d => d.BelongsToFaculty, cfg => cfg.MapFrom(d => d.Faculty.Name));
        }
    }
}
