namespace UMS.Services.Data.Models.PostsParametersModels
{
    public class PostCreateParametersModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
