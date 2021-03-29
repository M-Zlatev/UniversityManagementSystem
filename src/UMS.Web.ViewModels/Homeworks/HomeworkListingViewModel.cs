namespace UMS.Web.ViewModels.Homeworks
{
    using Data.Models.Homeworks;
    using Data.Common.Enumerations;
    using Services.Mapping.Contracts;

    public class HomeworkListingViewModel : IMapFrom<Homework>
    {
        public int Id { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public string DoneByStudent { get; set; }
    }
}
