namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Services.Data.Contracts;
    using ViewModels.Forum.Votes;

    [Area("Forum")]
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
            var user = this.userManager.GetUserAsync(this.User);
            inputModel.UserId = user.Id;

            await this.votesService.VoteAsync(inputModel);

            var votes = this.votesService.GetVotes(inputModel.PostId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
