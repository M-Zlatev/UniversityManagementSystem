namespace UMS.Web.ViewModels.Homeworks
{
    using Data.Models.Homeworks;
    using Services.Mapping.Contracts;

    public class EditHomeworkInputForm : HomeworkBaseForm, IMapFrom<Homework>
    {
        public int Id { get; set; }
    }
}
