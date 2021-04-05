namespace UMS.Services.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using Data.Models.CommentsParametersModels;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
            => this.commentsRepository = commentsRepository;

        public async Task Create(CommentCreateParametersModel model)
        {
            var comment = new Comment
            {
                Content = model.Content,
                ParentId = model.ParentId,
                PostId = model.PostId,
                UserId = model.UserId,
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
