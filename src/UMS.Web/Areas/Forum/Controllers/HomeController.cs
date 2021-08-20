namespace UMS.Web.Areas.Forum.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Services.Data.Contracts;
    using ViewModels.Additional;
    using ViewModels.Forum.Home;

    [Area("Forum")]
    public class HomeController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            ICategoriesService categoriesService,
            ILogger<HomeController> logger)
        {
            this.categoriesService = categoriesService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            this.TempData["InfoMessage"] = "Thank you for visiting our forum.";
            this.logger.LogCritical("Hello!");

            var viewModel = new IndexViewModel
            {
                Categories = this.categoriesService.GetAll<IndexCategoryViewModel>(1, 10),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
