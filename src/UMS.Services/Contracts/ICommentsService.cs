namespace UMS.Services.Contracts
{
    using System.Threading.Tasks;

    using Data.Models.CommentsParametersModels;
    using ServicesLifetimeContracts;

    public interface ICommentsService : ITransientService
    {
        Task Create(CommentCreateParametersModel createParametersmodel);

        bool IsInPostId(int commentId, int postId);
    }
}
