namespace UMS.Web.ViewModels.Faculties
{
    using AutoMapper;

    using Data.Models.Faculties;
    using Services.Mapping.Contracts;

    public class EditFacultyInputForm : FacultyBaseForm, IMapFrom<Faculty>, IMapExplicitly
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile.CreateMap<Faculty, EditFacultyInputForm>()
                 .ForMember(f => f.AddressStreetName, cfg => cfg.MapFrom(f => f.Address.StreetName))
                 .ForMember(f => f.AddressDistrictName, cfg => cfg.MapFrom(f => f.Address.District))
                 .ForMember(f => f.AddressTownName, cfg => cfg.MapFrom(f => f.Address.Town))
                 .ForMember(f => f.AddressPostalCode, cfg => cfg.MapFrom(f => f.Address.PostalCode))
                 .ForMember(f => f.AddressCountryName, cfg => cfg.MapFrom(f => f.Address.Country))
                 .ForMember(f => f.AddressContinentName, cfg => cfg.MapFrom(f => f.Address.Continent));
        }
    }
}
