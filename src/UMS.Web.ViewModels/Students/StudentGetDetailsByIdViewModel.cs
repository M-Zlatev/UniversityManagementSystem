namespace UMS.Web.ViewModels.Students
{
    using System;

    using AutoMapper;

    using Common.Mapping;
    using Data.Common.Enumerations;
    using Data.Models;

    public class StudentGetDetailsByIdViewModel : IMapFrom<Student>, IMapExplicitly
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UniformCivilNumber { get; set; }

        public DateTime? DateofBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }

        public string InMajor { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Student, StudentGetDetailsByIdViewModel>()
                .ForMember(s => s.AddressStreetName, cfg => cfg.MapFrom(s => s.Address.StreetName))
                .ForMember(s => s.AddressTownName, cfg => cfg.MapFrom(s => s.Address.Town))
                .ForMember(s => s.AddressDistrictName, cfg => cfg.MapFrom(s => s.Address.District))
                .ForMember(s => s.AddressCountryName, cfg => cfg.MapFrom(s => s.Address.Country))
                .ForMember(s => s.AddressContinentName, cfg => cfg.MapFrom(s => s.Address.Continent));
        }
    }
}
