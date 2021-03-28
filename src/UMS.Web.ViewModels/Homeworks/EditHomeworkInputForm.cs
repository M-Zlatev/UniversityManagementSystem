namespace UMS.Web.ViewModels.Homeworks
{
    using Common.Mapping;
    using Data.Models.Homeworks;

    public class EditHomeworkInputForm : HomeworkBaseForm, IMapFrom<Homework>
    {
        public int Id { get; set; }
    }
}
