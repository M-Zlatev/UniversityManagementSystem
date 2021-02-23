namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Teachers;

    public class TeacherEditParametersModel : TeacherBaseParametersModel, IMapFrom<EditTeacherInputForm>
    {
        public int Id { get; set; }
    }
}
