namespace UMS.Web.ViewModels.Students
{
    using Common.Mapping;
    using Data.Models;

    public class EditStudentInputForm : StudentBaseForm, IMapFrom<Student>
    {
        public int Id { get; set; }
    }
}
