namespace UMS.Data.Models.Resources
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Courses;
    using Common.Implementations;
    using static Common.DataValidation.Resource;

    public class Resource : BaseAuditInfoModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
