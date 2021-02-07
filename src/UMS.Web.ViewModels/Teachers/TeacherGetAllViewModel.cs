namespace UMS.Web.ViewModels.Teachers
{
    using System.Collections.Generic;

    public class TeacherGetAllViewModel : PagingViewModel
    {
        public IEnumerable<TeacherListingViewModel> Teachers { get; set; }
    }
}
