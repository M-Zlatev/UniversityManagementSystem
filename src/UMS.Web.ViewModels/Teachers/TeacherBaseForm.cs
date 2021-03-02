namespace UMS.Web.ViewModels.Teachers
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using Data.Models;
    using static Data.Common.DataValidation.Address;
    using static Data.Common.DataValidation.Teacher;

    public abstract class TeacherBaseForm
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

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

        public Gender Gender { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public AcademicDegree AcademicDegree { get; set; }

        [Required]
        public AcademicRank AcademicRank { get; set; }

        public string ImageUrl { get; set; }
    }
}
