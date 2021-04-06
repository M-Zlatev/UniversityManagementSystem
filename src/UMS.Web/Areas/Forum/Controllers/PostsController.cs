namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Services.Contracts;
    using Services.Data.Models.PostsParametersModels;
    using ViewModels.Forum.Posts;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<PostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePostInputForm();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostInputForm input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            input.UserId = user.Id;
            var parameters = Mapper.Map<PostCreateParametersModel>(input);

            var postId = await this.postsService.CreateAsync(parameters);
            this.TempData["InfoMessage"] = "Forum post created!";
            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }
    }
}
