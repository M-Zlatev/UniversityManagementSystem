namespace UMS.Web.ViewModels.Teachers
{
    using System;

    using AutoMapper;

    using Data.Common.Enumerations;
    using Data.Models.Teachers;
    using Services.Mapping.Contracts;

    public class TeacherGetDetailsByIdViewModel : IMapFrom<Teacher>, IMapExplicitly
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        public AcademicDegree AcademicDegree { get; set; }

        public AcademicRank AcademicRank { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
                 .CreateMap<Teacher, TeacherGetDetailsByIdViewModel>()
                 .ForMember(t => t.AddressStreetName, cfg => cfg.MapFrom(s => s.Address.StreetName))
                 .ForMember(t => t.AddressTownName, cfg => cfg.MapFrom(s => s.Address.Town))
                 .ForMember(t => t.AddressDistrictName, cfg => cfg.MapFrom(s => s.Address.District))
                 .ForMember(t => t.AddressCountryName, cfg => cfg.MapFrom(s => s.Address.Country))
                 .ForMember(t => t.AddressContinentName, cfg => cfg.MapFrom(s => s.Address.Continent));
        }
    }
}
