namespace UMS.Web.ViewModels.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models.Students;
    using Services.Mapping.Contracts;

    public class EditStudentInputForm : StudentBaseForm, IMapFrom<Student>, IMapExplicitly
    {
        public int Id { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile.CreateMap<Student, EditStudentInputForm>()
                .ForMember(s => s.AddressStreetName, cfg => cfg.MapFrom(s => s.Address.StreetName))
                .ForMember(s => s.AddressDistrictName, cfg => cfg.MapFrom(s => s.Address.District))
                .ForMember(s => s.AddressTownName, cfg => cfg.MapFrom(s => s.Address.Town))
                .ForMember(s => s.AddressPostalCode, cfg => cfg.MapFrom(s => s.Address.PostalCode))
                .ForMember(s => s.AddressCountryName, cfg => cfg.MapFrom(s => s.Address.Country))
                .ForMember(s => s.AddressContinentName, cfg => cfg.MapFrom(s => s.Address.Continent));
        }
    }
}
