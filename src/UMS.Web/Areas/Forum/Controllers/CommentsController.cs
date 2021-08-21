namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Services.Data.Contracts;
    using ViewModels.Forum.Comments;

    [Area("Forum")]
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
        public async Task<IActionResult> Create(CreateCommentInputForm createForm)
        {
            var parentId =
                createForm.ParentId == 0 ?
                    (int?)null :
                    createForm.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsInPostId(parentId.Value, createForm.PostId))
                {
                    return this.BadRequest();
                }
            }

            createForm.ParentId = parentId;

            var user = this.userManager.GetUserAsync(this.User);
            createForm.UserId = user.Id;

            await this.commentsService.Create(createForm);
            return this.RedirectToAction("ById", "Posts", new { id = createForm.PostId });
        }
    }
}
