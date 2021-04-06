namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Services.Contracts;
    using Services.Data.Models.VotesParametersModels;
    using ViewModels.Forum.Votes;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputForm inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);

            var parameters = Mapper.Map<VoteParametersModel>(inputModel);
            parameters.UserId = userId;

            await this.votesService.VoteAsync(parameters);

            var votes = this.votesService.GetVotes(inputModel.PostId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
