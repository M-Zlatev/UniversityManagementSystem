﻿namespace UMS.Services.Data.Models.Faculties
{
    using AutoMapper;

    using UMS.Data.Models;
    using Mapping;

    public class FacultyDetailsServiceModel : IMapFrom<Faculty>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressCountryName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Faculty, FacultyDetailsServiceModel>()
                .ForMember(f => f.AddressStreetName, cfg => cfg.MapFrom(f => f.Address.StreetName))
                .ForMember(f => f.AddressTownName, cfg => cfg.MapFrom(f => f.Address.Town))
                .ForMember(f => f.AddressCountryName, cfg => cfg.MapFrom(f => f.Address.Country));
        }
    }
}
