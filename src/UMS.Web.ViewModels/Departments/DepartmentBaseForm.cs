namespace UMS.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataValidation.Department;

    public abstract class DepartmentBaseForm
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxFaxNumberLength, MinimumLength = MinFaxNumberLength)]
        public string Fax { get; set; }
    }
}
