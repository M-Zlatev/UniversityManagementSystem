namespace UMS.Web.ViewModels
{
    using AutoMapper;

    using Data.Models.Departments;
    using Services.Mapping.Contracts;

    public class DepartmentGetDetailsByIdViewModel : IMapFrom<Department>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string BelongsToFaculty { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Department, DepartmentGetDetailsByIdViewModel>()
                .ForMember(d => d.BelongsToFaculty, cfg => cfg.MapFrom(d => d.Faculty.Name));
        }
    }
}
