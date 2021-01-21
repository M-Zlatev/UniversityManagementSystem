namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using static Common.DataValidation.Department;

    public class Department : BaseModel
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
