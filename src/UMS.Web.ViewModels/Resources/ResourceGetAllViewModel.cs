namespace UMS.Web.ViewModels.Resources
{
    using System.Collections.Generic;

    using Additional;

    public class ResourceGetAllViewModel : PagingViewModel
    {
        public IEnumerable<ResourceListingViewModel> Resources { get; set; }
    }
}
