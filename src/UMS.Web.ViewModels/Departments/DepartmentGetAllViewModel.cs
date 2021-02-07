namespace UMS.Web.ViewModels.Departments
{
    using System.Collections.Generic;

    public class DepartmentGetAllViewModel : PagingViewModel
    {
        public IEnumerable<DepartmentListingViewModel> Departments { get; set; }
    }
}
