namespace UMS.Services.Data.Models.PostsParametersModels
{
    using Mapping.Contracts;
    using Web.ViewModels.Forum.Posts;

    public class PostCreateParametersModel : IMapFrom<CreatePostInputForm>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
