namespace UMS.Data.Models.Departments
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Implementations;
    using Majors;
    using Faculties;
    using static Common.DataValidation.Department;

    public class Department : BaseDeletableModel
    {
        public Department()
        {
            this.Majors = new HashSet<Major>();
        }

        public int Id { get; set; }

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
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxFaxNumberLength, MinimumLength = MinFaxNumberLength)]
        public string Fax { get; set; }

        public string ImageUrl { get; set; }

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}
