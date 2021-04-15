namespace UMS.Web.ViewModels.Forum.Categories
{
    using Data.Models.Forum;
    using Services.Mapping.Contracts;

    public class CategoryListingViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
