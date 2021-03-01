namespace UMS.Web.ViewModels.Homeworks
{
    using Common.Mapping;
    using Data.Models;
    using Data.Common.Enumerations;

    public class HomeworkListingViewModel : IMapFrom<Homework>
    {
        public int Id { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public string DoneByStudent { get; set; }
    }
}
