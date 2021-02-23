namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Faculties;

    public class FacultyEditParametersModel : FacultyBaseParametersModel, IMapFrom<EditFacultyInputForm>
    {
        public int Id { get; set; }
    }
}
