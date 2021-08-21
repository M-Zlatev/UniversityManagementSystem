namespace UMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.Homeworks;
    using Data.Models.UserDefinedPrincipal;
    using Data.Repositories.Contracts;
    using Services.Data.Contracts;
    using ViewModels.Homeworks;

    public class HomeworksController : Controller
    {
        private readonly IRepository<Homework> homeworkRepository;
        private readonly IHomeworksService homeworksService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeworksController(
            IHomeworksService homeworksService,
            IRepository<Homework> homeworkRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.homeworksService = homeworksService;
            this.homeworkRepository = homeworkRepository;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int HomeworksPerPage = 10;

            var viewModel = new HomeworkGetAllViewModel
            {
                ItemsPerPage = HomeworksPerPage,
                Count = this.homeworksService.GetCount(),
                PageNumber = id,
                Homeworks = this.homeworksService.GetAll<HomeworkListingViewModel>(id, HomeworksPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.homeworksService.GetDetailsById<HomeworkGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int id)
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateHomeworkInputForm createForm)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                createForm.UserId = user.Id;
                var homeworkId = await this.homeworksService.CreateAsync(createForm);

                return this.RedirectToAction(nameof(this.ById), new { id = homeworkId });
            }

            return this.View(createForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.homeworksService.GetDetailsById<EditHomeworkInputForm>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditHomeworkInputForm editForm)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                editForm.UserId = user.Id;
                await this.homeworksService.EditAsync(id, editForm);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(editForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            var homework = this.homeworkRepository.All()
                .Where(d => d.Id == id)
                .FirstOrDefault();

            return this.View(homework);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            await this.homeworksService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
