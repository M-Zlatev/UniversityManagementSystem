namespace UMS.Web.ViewModels.Homeworks
{
    using System.Collections.Generic;

    public class HomeworkGetAllViewModel : PagingViewModel
    {
        public IEnumerable<HomeworkListingViewModel> Homeworks { get; set; }
    }
}
