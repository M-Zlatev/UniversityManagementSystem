namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Teachers;

    public class TeacherCreateParametersModel : TeacherBaseParametersModel, IMapFrom<CreateTeacherInputForm>
    {
        public string UserId { get; set; }
    }
}
