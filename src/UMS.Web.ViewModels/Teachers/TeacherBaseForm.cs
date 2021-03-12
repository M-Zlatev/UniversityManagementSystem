namespace UMS.Web.ViewModels.Teachers
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using Data.Models;
    using static Data.Common.DataValidation.Teacher;

    public abstract class TeacherBaseForm : BaseAddress
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

        public Gender Gender { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Academic degree")]
        public AcademicDegree AcademicDegree { get; set; }

        [Required]
        [Display(Name = "Academic rank")]
        public AcademicRank AcademicRank { get; set; }

        public string ImageUrl { get; set; }
    }
}
