namespace UMS.Web.ViewModels.Forum.Posts
{
    public class GetByCategoryIdViewModel
    {
        public int Skip { get; set; } = 0;

        public int? Take { get; set; } = null;

        public int CategoryId { get; set; }
    }
}
