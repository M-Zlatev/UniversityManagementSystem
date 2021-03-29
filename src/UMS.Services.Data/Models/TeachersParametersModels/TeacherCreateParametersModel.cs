namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Teachers;

    public class TeacherCreateParametersModel : TeacherBaseParametersModel, IMapFrom<CreateTeacherInputForm>
    {
        public string UserId { get; set; }
    }
}
