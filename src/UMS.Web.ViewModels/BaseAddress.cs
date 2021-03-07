namespace UMS.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.Address;

    public abstract class BaseAddress
    {
        [Required]
        [StringLength(MaxStreetNameLength, MinimumLength = MinStreetNameLength)]
        public string AddressStreetName { get; set; }

        [MaxLength(MaxDistrictNameLength)]
        public string AddressDistrictName { get; set; }

        [Required]
        [StringLength(MaxTownNameLength, MinimumLength = MinTownNameLength)]
        public string AddressTownName { get; set; }

        [StringLength(MaxPostalCodeLength, MinimumLength = MinPostalCodeLength)]
        public string AddressPostalCode { get; set; }

        [Required]
        [StringLength(MaxCountryNameLength, MinimumLength = MinCountryNameLength)]
        public string AddressCountryName { get; set; }

        public Continent AddressContinentName { get; set; }
    }
}
