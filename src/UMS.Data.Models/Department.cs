namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using static UMS.Data.Common.DataValidation.Department;

    public class Department
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

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}
