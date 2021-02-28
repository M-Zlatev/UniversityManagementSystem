namespace UMS.Web.ViewModels.Faculties
{
    using Common.Mapping;
    using Data.Models;

    public class EditFacultyInputForm : FacultyBaseForm, IMapFrom<Faculty>
    {
        public int Id { get; set; }
    }
}
