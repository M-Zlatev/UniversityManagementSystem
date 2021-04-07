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
    [Route("Categories")]
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

        [HttpGet("{id}")]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int CategoryPerPage = 10;

            var viewModel = new CategoryGetAllViewModel
            {
                ItemsPerPage = CategoryPerPage,
                Count = this.categoriesService.GetCount(),
                PageNumber = id,
                Categories = this.categoriesService.GetAll<CategoryListingViewModel>(id, CategoryPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            var parameters = Mapper.Map<GetByCategoryIdParametersModel>(viewModel);
            viewModel.ForumPosts = this.postsService.GetByCategoryId<PostInCategoryViewModel>(parameters);

            return this.View(viewModel);
        }
    }
}
