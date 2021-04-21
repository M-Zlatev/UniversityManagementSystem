namespace UMS.Web.Areas.Forum.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Services.Contracts;
    using Services.Data.Models.PostsParametersModels;
    using ViewModels.Forum.Categories;
    using ViewModels.Forum.Posts;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    [Area("Forum")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            const int PageNumber = 1;
            const int PostsPerPage = 10;
            int categoryId = viewModel.Id;

            viewModel.Count = this.postsService.GetCountByCategoryId(categoryId);
            viewModel.ItemsPerPage = PostsPerPage;
            viewModel.PageNumber = PageNumber;
            viewModel.ForumPosts = this.postsService.GetByCategoryId<PostInCategoryViewModel>(categoryId);

            return this.View(viewModel);
        }
    }
}
