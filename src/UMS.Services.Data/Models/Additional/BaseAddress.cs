namespace UMS.Services.Data.Models.Additional
{
    using UMS.Data.Common.Enumerations;

    public abstract class BaseAddress
    {
        public string AddressStreetName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressPostalCode { get; set; }

        public string AddressCountryName { get; set; }

        public Continent AddressContinentName { get; set; }
    }
}
