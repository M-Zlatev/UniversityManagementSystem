namespace UMS.Data.Models.Courses
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Implementations;
    using Resources;
    using UserDefinedPrincipal;
    using static Common.DataValidation.Course;

    public class Course : BaseDeletableModel
    {
        public Course()
        {
            this.Majors = new HashSet<CourseMajor>();
            this.User = new HashSet<ApplicationUserCourse>();
            this.Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(MinPrice, MaxPrice)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<CourseMajor> Majors { get; set; }

        public virtual ICollection<ApplicationUserCourse> User { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
