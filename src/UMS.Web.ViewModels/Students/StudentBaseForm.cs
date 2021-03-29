namespace UMS.Web.ViewModels.Students
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Additional;
    using Data.Common.Enumerations;
    using Data.Models;
    using static Data.Common.DataValidation.Student;

    public abstract class StudentBaseForm : BaseAddress
    {
        [Required]
        [MaxLength(MaxNameLength)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(MaxUCNLength, MinimumLength = MinUCNLength, ErrorMessage = UCNErrorMessage)]
        [Display(Name = "Uniform civil number")]
        public string UniformCivilNumber { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        [EmailAddress]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Scholarship")]
        public bool HasScholarship { get; set; }

        [Display(Name = "Registration date")]
        public DateTime? RegistrationDate { get; set; }
    }
}
