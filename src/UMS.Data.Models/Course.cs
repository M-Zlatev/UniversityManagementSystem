namespace UMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static UMS.Data.Common.DataValidation.Course;

    public class Course
    {
        public Course()
        {
            this.StartDate = DateTime.UtcNow;
            this.EndDate = DateTime.UtcNow.AddMonths(6);
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

        public ICollection<TeacherCourse> Teachers { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
