namespace UMS.Web.Models.Faculty
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataValidation.Address;
    using static Data.Common.DataValidation.Faculty;

    public class FacultyFormModel
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Range(MinStreetNameLength, MaxStreetNameLength)]
        public string AddressStreetName { get; set; }

        [Range(MinTownNameLength, MaxTownNameLength)]
        public string AddressTownName { get; set; }

        [Range(MinCountryNameLength, MaxCountryNameLength)]
        public string AddressCountryName { get; set; }

        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Range(MinFaxNumberLength, MaxFaxNumberLength)]
        public string Fax { get; set; }
    }
}
