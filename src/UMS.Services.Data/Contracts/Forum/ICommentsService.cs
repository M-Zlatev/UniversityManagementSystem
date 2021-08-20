namespace UMS.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using Web.ViewModels.Forum.Comments;

    public interface ICommentsService : ITransientService
    {
        Task Create(CreateCommentInputForm createForm);

        bool IsInPostId(int commentId, int postId);
    }
}
