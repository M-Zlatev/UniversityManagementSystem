namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Implementations;
    using static Common.DataValidation.Faculty;

    public class Faculty : BaseDeletableModel
    {
        public Faculty()
        {
            this.Departments = new HashSet<Department>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public FacultyAddress Address { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxFaxNumberLength, MinimumLength = MinFaxNumberLength)]
        public string Fax { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
