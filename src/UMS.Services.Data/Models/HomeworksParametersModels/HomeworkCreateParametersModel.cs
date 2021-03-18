namespace UMS.Services.Data.Models.HomeworksParametersModels
{
    using System;

    using Common.Mapping;
    using UMS.Web.ViewModels.Homeworks;

    public class HomeworkCreateParametersModel : HomeworkBaseParametersModel, IMapFrom<CreateHomeworkInputForm>
    {
        public DateTime AssingmentTime { get; set; }
    }
}
