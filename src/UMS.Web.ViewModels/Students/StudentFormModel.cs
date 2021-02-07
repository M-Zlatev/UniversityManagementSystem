namespace UMS.Web.ViewModels.Students
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using Data.Models;
    using static Data.Common.DataValidation.Student;

    public class StudentFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must contains 10 digits")]
        public int UniformCivilNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddressStreetName { get; set; }

        [Required]
        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        [Required]
        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        [Required]
        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }

        public string MajorName { get; set; }
    }
}
