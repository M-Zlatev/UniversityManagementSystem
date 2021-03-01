namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using UMS.Data.Common.Enumerations;

    public abstract class FacultyBaseParametersModel
    {
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
    }
}
