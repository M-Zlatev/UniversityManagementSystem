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
            this.StudentsEnrolled = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}
