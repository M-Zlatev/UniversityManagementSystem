namespace UMS.Web.ViewModels.Resources
{
    using System.Collections.Generic;

    public class ResourceGetAllViewModel : PagingViewModel
    {
        public IEnumerable<ResourceListingViewModel> Resources { get; set; }
    }
}
