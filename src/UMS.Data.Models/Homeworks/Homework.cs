namespace UMS.Data.Models.Homeworks
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Common.Implementations;
    using Students;
    using UserDefinedPrincipal;
    using static Common.DataValidation.Homework;

    public class Homework : BaseAuditInfoModel
    {
        public Homework()
        {
            this.OpenForSubmissionTime = DateTime.UtcNow.AddDays(7);
        }

        public int Id { get; set; }

        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        [Required]
        public HomeworkType HomeworkType { get; set; }

        [Required]
        public DateTime AssignmentTime { get; set; }

        public DateTime OpenForSubmissionTime { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }
    }
}
