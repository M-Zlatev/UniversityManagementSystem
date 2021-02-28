namespace UMS.Web.ViewModels.Teachers
{
    using Common.Mapping;
    using Data.Models;

    public class EditTeacherInputForm : TeacherBaseForm, IMapFrom<Teacher>
    {
        public int Id { get; set; }
    }
}
