namespace UMS.Web.ViewModels.Homeworks
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.Homework;

    public abstract class HomeworkBaseForm
    {
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Homework type")]
        public HomeworkType HomeworkType { get; set; }

        [Display(Name = "Open for submission time")]
        public DateTime OpenForSubmissionTime { get; set; }

        public int UserId { get; set; }
    }
}
