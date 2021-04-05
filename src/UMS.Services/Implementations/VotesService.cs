namespace UMS.Services.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using Data.Models.VotesParametersModels;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
            => this.votesRepository = votesRepository;

        public int GetVotes(int postId)
            => this.votesRepository.All()
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);

        public async Task VoteAsync(VoteParametersModel model)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.PostId == model.PostId && x.UserId == model.UserId);

            if (vote != null)
            {
                vote.Type = model.IsUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = model.PostId,
                    UserId = model.UserId,
                    Type = model.IsUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
