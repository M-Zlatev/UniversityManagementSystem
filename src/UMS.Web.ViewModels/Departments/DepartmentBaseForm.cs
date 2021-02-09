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

        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Range(MinFaxNumberLength, MaxFaxNumberLength)]
        public string Fax { get; set; }

        public string BelongsToFaculty { get; set; }
    }
}
