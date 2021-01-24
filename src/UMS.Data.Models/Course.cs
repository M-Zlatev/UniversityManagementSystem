namespace UMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;
    using static Common.DataValidation.Course;

    public class Course : BaseDeletableModel
    {
        public Course()
        {
            this.StartDate = DateTime.UtcNow;
            this.EndDate = DateTime.UtcNow.AddMonths(6);
            this.Majors = new HashSet<CourseMajor>();
            this.Teachers = new HashSet<TeacherCourse>();
            this.StudentsEnrolled = new HashSet<StudentCourse>();
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

        public virtual ICollection<TeacherCourse> Teachers { get; set; }

        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
