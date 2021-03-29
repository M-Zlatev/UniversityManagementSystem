namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Teachers;

    public class TeacherEditParametersModel : TeacherBaseParametersModel, IMapFrom<EditTeacherInputForm>
    {
        public int Id { get; set; }
    }
}
