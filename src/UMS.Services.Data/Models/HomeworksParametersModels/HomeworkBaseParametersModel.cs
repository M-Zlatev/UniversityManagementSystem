namespace UMS.Services.Data.Models.HomeworksParametersModels
{
    using System;

    using UMS.Data.Common.Enumerations;

    public class HomeworkBaseParametersModel
    {
        public string Content { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public DateTime OpenForSubmissionTime { get; set; }

        public string UserId { get; set; }
    }
}
