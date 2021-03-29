namespace UMS.Web.ViewModels.Majors
{
    using System.Collections.Generic;

    using Additional;

    public class MajorGetAllViewModel : PagingViewModel
    {
        public IEnumerable<MajorListingViewModel> Majors { get; set; }
    }
}
