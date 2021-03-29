namespace UMS.Web.ViewModels
{
    using AutoMapper;

    using Data.Common.Enumerations;
    using Data.Models.Majors;
    using Services.Mapping.Contracts;

    public class MajorGetDetailsByIdViewModel : IMapFrom<Major>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MajorType MajorType { get; set; }

        public double Duration { get; set; }

        public string BelongsToDepartment { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Major, MajorGetDetailsByIdViewModel>()
                .ForMember(m => m.BelongsToDepartment, cfg => cfg.MapFrom(m => m.Department.Name));
        }
    }
}
