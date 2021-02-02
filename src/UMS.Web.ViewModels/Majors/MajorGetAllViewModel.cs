namespace UMS.Web.ViewModels.Majors
{
    using System.Collections.Generic;

    public class MajorGetAllViewModel : PagingViewModel
    {
        public IEnumerable<MajorListingViewModel> GetAllMajorViewModel { get; set; }
    }
}
