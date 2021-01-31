namespace UMS.Web.ViewModels
{
    using AutoMapper;

    using Data.Models;
    using Services.Mapping;

    public class DepartmentDetailsServiceModel : IMapFrom<Department>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string BelongsToFaculty { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Department, DepartmentDetailsServiceModel>()
                .ForMember(d => d.BelongsToFaculty, cfg => cfg.MapFrom(d => d.Faculty.Name));
        }
    }
}
