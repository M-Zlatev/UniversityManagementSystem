namespace UMS.Web.ViewModels.Forum.Categories
{
    using System.Collections.Generic;

    using Additional;

    public class CategoryViewModel : PagingViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<PostInCategoryViewModel> ForumPosts { get; set; }
    }
}
