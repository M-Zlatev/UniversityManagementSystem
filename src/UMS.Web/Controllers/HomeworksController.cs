namespace UMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure;
    using Services.Data.Models.HomeworksParametersModels;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Homeworks;

    public class HomeworksController : Controller
    {
        private readonly IRepository<Homework> homeworkRepository;
        private readonly IHomeworksService homeworksService;

        public HomeworksController(IHomeworksService homeworksService, IRepository<Homework> homeworkRepository)
        {
            this.homeworksService = homeworksService;
            this.homeworkRepository = homeworkRepository;
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
        public IActionResult Create(int id)
            => this.View();

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CreateHomeworkInputForm inputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<HomeworkCreateParametersModel>(inputForm);
                var homeworkId = await this.homeworksService.Create(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = homeworkId });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        //[Authorize]
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
        //[Authorize]
        public async Task<IActionResult> Edit(int id, EditHomeworkInputForm inputForm)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<HomeworkEditParametersModel>(inputForm);
                await this.homeworksService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        //[Authorize]
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
        [ActionName("Delete")]
        //[Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            await this.homeworksService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
