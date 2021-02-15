namespace UMS.Web.ViewModels.Homeworks
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using UMS.Data.Common.Enumerations;
    using static Data.Common.DataValidation.Homework;

    public abstract class HomeworkBaseForm
    {
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        [Required]
        public HomeworkType HomeworkType { get; set; }

        [Required]
        public DateTime AssignmentTime { get; set; }

        public DateTime OpenForSubmissionTime { get; set; }
    }
}
