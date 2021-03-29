namespace UMS.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Additional;
    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.Faculty;

    public abstract class FacultyBaseForm : BaseAddress
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxFaxNumberLength, MinimumLength = MinFaxNumberLength)]
        public string Fax { get; set; }
    }
}
