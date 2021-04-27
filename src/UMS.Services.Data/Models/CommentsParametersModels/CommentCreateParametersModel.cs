namespace UMS.Services.Data.Models.CommentsParametersModels
{
    using Mapping.Contracts;
    using Web.ViewModels.Forum.Comments;

    public class CommentCreateParametersModel : IMapFrom<CreateCommentInputForm>
    {
        public string Content { get; set; }

        public int? ParentId { get; set; } = null;

        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}
