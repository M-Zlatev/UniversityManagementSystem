namespace UMS.Web.ViewModels.Students
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using Data.Models;
    using static Data.Common.DataValidation.Student;

    public abstract class StudentBaseForm : BaseAddress
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
        [StringLength(MaxUCNLength, MinimumLength = MinUCNLength, ErrorMessage = UCNErrorMessage)]
        [Display(Name = DisplayName)]
        public string UniformCivilNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        [EmailAddress]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }

        public DateTime? RegistrationDate { get; set; }
    }
}
