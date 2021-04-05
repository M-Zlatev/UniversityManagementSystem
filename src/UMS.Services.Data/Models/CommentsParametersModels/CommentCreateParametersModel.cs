namespace UMS.Services.Data.Models.CommentsParametersModels
{
    public class CommentCreateParametersModel
    {
        public string Content { get; set; }

        public int? ParentId { get; set; } = null;

        public int PostId { get; set; }

        public string UserId { get; set; }
    }
}
