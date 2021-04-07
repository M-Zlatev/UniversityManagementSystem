namespace UMS.Web.ViewModels.Forum.Home
{
    using Data.Models.Forum;
    using Services.Mapping.Contracts;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}