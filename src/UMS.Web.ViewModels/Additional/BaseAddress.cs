namespace UMS.Web.ViewModels.Additional
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.Address;

    public abstract class BaseAddress
    {
        [Required]
        [StringLength(MaxStreetNameLength, MinimumLength = MinStreetNameLength)]
        [Display(Name = "Address street name")]
        public string AddressStreetName { get; set; }

        [MaxLength(MaxDistrictNameLength)]
        [Display(Name = "Address district name")]
        public string AddressDistrictName { get; set; }

        [Required]
        [StringLength(MaxTownNameLength, MinimumLength = MinTownNameLength)]
        [Display(Name = "Address town name")]
        public string AddressTownName { get; set; }

        [StringLength(MaxPostalCodeLength, MinimumLength = MinPostalCodeLength)]
        [Display(Name = "Address postal code")]
        public string AddressPostalCode { get; set; }

        [Required]
        [StringLength(MaxCountryNameLength, MinimumLength = MinCountryNameLength)]
        [Display(Name = "Address country name")]
        public string AddressCountryName { get; set; }

        [Display(Name = "Address continent name")]
        public Continent AddressContinentName { get; set; }
    }
}
