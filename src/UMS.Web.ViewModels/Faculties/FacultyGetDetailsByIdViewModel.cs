namespace UMS.Web.ViewModels
{
    using AutoMapper;

    using Data.Common.Enumerations;
    using Data.Models.Faculties;
    using Services.Mapping.Contracts;

    public class FacultyGetDetailsByIdViewModel : IMapFrom<Faculty>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressPostalCode { get; set; }

        public string AddressCountryName { get; set; }

        public Continent AddressContinent { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Faculty, FacultyGetDetailsByIdViewModel>()
                .ForMember(f => f.AddressStreetName, cfg => cfg.MapFrom(f => f.Address.StreetName))
                .ForMember(f => f.AddressDistrictName, cfg => cfg.MapFrom(f => f.Address.District))
                .ForMember(f => f.AddressTownName, cfg => cfg.MapFrom(f => f.Address.Town))
                .ForMember(f => f.AddressPostalCode, cfg => cfg.MapFrom(f => f.Address.PostalCode))
                .ForMember(f => f.AddressCountryName, cfg => cfg.MapFrom(f => f.Address.Country))
                .ForMember(f => f.AddressContinent, cfg => cfg.MapFrom(f => f.Address.Continent));
        }
    }
}
