namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Services.Contracts;
    using Services.Data.Models.CommentsParametersModels;
    using ViewModels.Forum.Comments;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputForm model)
        {
            var parentId =
                model.ParentId == 0 ?
                    (int?)null :
                    model.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsInPostId(parentId.Value, model.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            model.ParentId = parentId;
            model.UserId = userId;

            var parameters = Mapper.Map<CommentCreateParametersModel>(model);

            await this.commentsService.Create(parameters);

            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}
