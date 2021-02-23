namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Students;

    public class StudentCreateParametersModel : StudentBaseParametersModel, IMapFrom<CreateStudentInputForm>
    {
        public int UserId { get; set; }
    }
}
