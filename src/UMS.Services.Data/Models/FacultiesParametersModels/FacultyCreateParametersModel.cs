namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Faculties;

    public class FacultyCreateParametersModel : FacultyBaseParametersModel, IMapFrom<CreateFacultyInputForm>
    {
        public string UserId { get; set; }
    }
}
