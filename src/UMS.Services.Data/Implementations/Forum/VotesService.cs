namespace UMS.Services.Data.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Forum.Votes;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
            => this.votesRepository = votesRepository;

        public int GetVotes(int postId)
            => this.votesRepository.All()
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);

        public async Task VoteAsync(VoteInputForm inputForm)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.PostId == inputForm.PostId && x.UserId == inputForm.UserId);

            if (vote != null)
            {
                vote.Type = inputForm.IsUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = inputForm.PostId,
                    UserId = inputForm.UserId,
                    Type = inputForm.IsUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
