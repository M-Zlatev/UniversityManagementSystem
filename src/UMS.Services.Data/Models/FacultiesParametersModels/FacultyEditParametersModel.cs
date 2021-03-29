namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Faculties;

    public class FacultyEditParametersModel : FacultyBaseParametersModel, IMapFrom<EditFacultyInputForm>
    {
        public int Id { get; set; }
    }
}
