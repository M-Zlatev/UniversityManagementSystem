namespace UMS.Services.Mapping
{
    using System;

    using AutoMapper;

    using Data.Models.Departments;
    using Data.Models.Faculties;
    using Data.Models.Majors;
    using UMS.Data.Models;

    public class ServiceMappingPorfile : Profile
    {
        public ServiceMappingPorfile()
        {
            this.CreateMap<Faculty, FacultyListingServiceModel>();

            this.CreateMap<Faculty, FacultyDetailsServiceModel>()
                .ForMember(f => f.AddressStreetName, cfg => cfg.MapFrom(f => f.Address.StreetName))
                .ForMember(f => f.AddressTownName, cfg => cfg.MapFrom(f => f.Address.Town))
                .ForMember(f => f.AddressCountryName, cfg => cfg.MapFrom(f => f.Address.Country));

            this.CreateMap<Department, DepartmentListingServiceModel>()
                .ForMember(d => d.BelongsToFaculty, cfg => cfg.MapFrom(d => d.Faculty.Name));

            this.CreateMap<Department, DepartmentDetailsServiceModel>()
                .ForMember(d => d.BelongsToFaculty, cfg => cfg.MapFrom(d => d.Faculty.Name));

            this.CreateMap<Major, MajorListingServiceModel>();

            this.CreateMap<Major, MajorDetailsServiceModel>()
                .ForMember(m => m.BelongsToDepartment, cfg => cfg.MapFrom(m => m.Department.Name));
        }
    }
}
