namespace UMS.Services.Data.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Forum.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
            => this.commentsRepository = commentsRepository;

        public async Task Create(CreateCommentInputForm createForm)
        {
            var comment = new Comment
            {
                Content = createForm.Content,
                ParentId = createForm.ParentId,
                PostId = createForm.PostId,
                UserId = createForm.UserId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsRepository.All()
                .Where(x => x.Id == commentId)
                .Select(x => x.PostId)
                .FirstOrDefault();

            return commentPostId == postId;
        }
    }
}
