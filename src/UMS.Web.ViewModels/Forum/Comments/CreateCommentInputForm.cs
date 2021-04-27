namespace UMS.Web.ViewModels.Forum.Comments
{
    public class CreateCommentInputForm
    {
        public string Content { get; set; }

        public int? ParentId { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}
