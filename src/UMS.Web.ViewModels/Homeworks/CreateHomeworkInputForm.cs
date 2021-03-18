namespace UMS.Web.ViewModels.Homeworks
{
    using System;

    using System.ComponentModel.DataAnnotations;

    public class CreateHomeworkInputForm : HomeworkBaseForm
    {
        [Required]
        [Display(Name = "Assignment time")]

        public DateTime AssignmentTime { get; set; }
    }
}
