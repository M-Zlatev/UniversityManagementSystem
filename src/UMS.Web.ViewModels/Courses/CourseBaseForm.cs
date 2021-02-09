namespace UMS.Web.ViewModels.Courses
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Data.Common.DataValidation.Course;

    public abstract class CourseBaseForm
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [Range(MinPrice, MaxPrice)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string BelongsToMajor { get; set; }
    }
}
