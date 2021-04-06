namespace UMS.Web.ViewModels.Forum.Categories
{
    using System.Collections.Generic;

    using Additional;

    public class CategoryGetAllViewModel : PagingViewModel
    {
        public IEnumerable<CategoryListingViewModel> Categories { get; set; }
    }
}
