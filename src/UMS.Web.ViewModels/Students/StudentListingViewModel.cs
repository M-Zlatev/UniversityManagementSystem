namespace UMS.Web.ViewModels.Students
{
    using System.Linq;

    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class StudentListingViewModel : IMapFrom<Student>, IMapExplicitly
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Major { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Student, StudentListingViewModel>()
                .ForMember(s => s.Major, cfg => cfg.MapFrom(
                    s => s.Majors
                    .Select(sm => sm.Major.Name)
                    .FirstOrDefault()));
        }
    }
}
