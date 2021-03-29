namespace UMS.Web.ViewModels.Courses
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Data.Models.Courses;
    using Services.Mapping.Contracts;

    public class CourseGetDetailsByIdViewModel : IMapFrom<Course>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string BelongsToMajor { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
               .CreateMap<Course, CourseGetDetailsByIdViewModel>()
               .ForMember(c => c.BelongsToMajor, cfg => cfg.MapFrom(
                   c => c.Majors
                            .Select(cm => cm.Major.Name)
                            .FirstOrDefault()));
        }
    }
}
