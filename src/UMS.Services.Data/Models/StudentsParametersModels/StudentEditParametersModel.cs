namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Students;

    public class StudentEditParametersModel : StudentBaseParametersModel, IMapFrom<EditStudentInputForm>
    {
        public int Id { get; set; }
    }
}
