namespace UMS.Web.ViewModels.Faculties
{
    using System.Collections.Generic;

    using Additional;

    public class FacultyGetAllViewModel : PagingViewModel
    {
        public IEnumerable<FacultyListingViewModel> Faculties { get; set; }
    }
}
