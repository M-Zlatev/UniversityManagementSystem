namespace UMS.Web.ViewModels.Teachers
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using Data.Models;
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

        public Gender Gender { get; set; }

        [Required]
        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        [Required]
        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public string AddressStreetName { get; set; }

        [Required]
        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        [Required]
        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        [Required]
        public AcademicDegree AcademicDegree { get; set; }

        [Required]
        public AcademicRank AcademicRank { get; set; }

        public string ImageUrl { get; set; }
    }
}
