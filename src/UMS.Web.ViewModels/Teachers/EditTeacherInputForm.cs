namespace UMS.Web.ViewModels.Teachers
{
    using AutoMapper;

    using Data.Models.Teachers;
    using Services.Mapping.Contracts;

    public class EditTeacherInputForm : TeacherBaseForm, IMapFrom<Teacher>, IMapExplicitly
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile.CreateMap<Teacher, EditTeacherInputForm>()
                .ForMember(t => t.AddressStreetName, cfg => cfg.MapFrom(t => t.Address.StreetName))
                .ForMember(t => t.AddressDistrictName, cfg => cfg.MapFrom(t => t.Address.District))
                .ForMember(t => t.AddressTownName, cfg => cfg.MapFrom(t => t.Address.Town))
                .ForMember(t => t.AddressPostalCode, cfg => cfg.MapFrom(t => t.Address.PostalCode))
                .ForMember(t => t.AddressCountryName, cfg => cfg.MapFrom(t => t.Address.Country))
                .ForMember(t => t.AddressContinentName, cfg => cfg.MapFrom(t => t.Address.Continent));
        }
    }
}
