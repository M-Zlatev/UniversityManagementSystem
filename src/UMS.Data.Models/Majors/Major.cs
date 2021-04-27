namespace UMS.Data.Models.Majors
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Common.Implementations;
    using Courses;
    using Departments;
    using UserDefinedPrincipal;
    using static Common.DataValidation.Major;

    public class Major : BaseDeletableModel
    {
        public Major()
        {
            this.Courses = new HashSet<CourseMajor>();
            this.User = new HashSet<ApplicationUserMajor>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public MajorType MajorType { get; set; }

        [Required]
        [Range(MinRangeInYears, MaxRangeInYears)]
        public double Duration { get; set; }

        public string ImageUrl { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<CourseMajor> Courses { get; set; }

        public virtual ICollection<ApplicationUserMajor> User { get; set; }
    }
}
