namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Infrastructure;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Homeworks;

    public class HomeworksController : Controller
    {
        private readonly IHomeworksService homeworksService;

        public HomeworksController(IHomeworksService homeworksService)
            => this.homeworksService = homeworksService;

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
        [Authorize]
        public async Task<IActionResult> Create(CreateHomeworkInputForm inputForm)
        {
            if (this.ModelState.IsValid)
            {
                var courseId = await this.homeworksService.Create(inputForm.Content, inputForm.HomeworkType, inputForm.AssignmentTime, inputForm.OpenForSubmissionTime, inputForm.UserId);

                return this.RedirectToAction(nameof(this.ById), new { id = courseId });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditHomeworkInputForm inputForm)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.homeworksService.Edit(id, inputForm.Content, inputForm.HomeworkType, inputForm.AssignmentTime, inputForm.OpenForSubmissionTime);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.homeworksService.Exists(id))
            {
                return this.NotFound();
            }

            await this.homeworksService.Delete(id);

            return this.Redirect(nameof(this.All));
        }
    }
}
