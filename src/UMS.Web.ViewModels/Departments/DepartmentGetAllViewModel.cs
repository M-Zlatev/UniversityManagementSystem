namespace UMS.Web.ViewModels.Departments
{
    using System.Collections.Generic;

    using Additional;

    public class DepartmentGetAllViewModel : PagingViewModel
    {
        public IEnumerable<DepartmentListingViewModel> Departments { get; set; }
    }
}
