namespace UMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using UMS.Data.Common.Implementations;
    using static UMS.Data.Common.DataValidation.Resource;

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
