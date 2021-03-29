namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Faculties;

    public class FacultyCreateParametersModel : FacultyBaseParametersModel, IMapFrom<CreateFacultyInputForm>
    {
        public string UserId { get; set; }
    }
}
