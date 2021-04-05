namespace UMS.Services.Contracts
{
    using System.Threading.Tasks;

    using Data.Models.VotesParametersModels;
    using ServicesLifetimeContracts;

    public interface IVotesService : ITransientService
    {
        int GetVotes(int postId);

        Task VoteAsync(VoteParametersModel voteParametersModel);
    }
}
