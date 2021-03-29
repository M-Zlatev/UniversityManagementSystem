namespace UMS.Web.ViewModels.Students
{
    using System.Collections.Generic;

    using Additional;

    public class StudentGetAllViewModel : PagingViewModel
    {
        public IEnumerable<StudentListingViewModel> Students { get; set; }
    }
}
