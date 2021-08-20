namespace UMS.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Web.ViewModels.Forum.Votes;

    public interface IVotesService : ITransientService
    {
        int GetVotes(int postId);

        Task VoteAsync(VoteInputForm inputForm);
    }
}
