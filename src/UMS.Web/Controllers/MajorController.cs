namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Models.Major;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Majors;

    public class MajorController : Controller
    {
        private readonly IMajorService majorService;

        public MajorController(IMajorService majors)
            => this.majorService = majors;

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int MajorsPerPage = 10;

            var viewModel = new MajorGetAllViewModel
            {
                ItemsPerPage = MajorsPerPage,
                PageNumber = id,
                GetAllMajorViewModel = this.majorService.GetAll<MajorListingViewModel>(id, MajorsPerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(MajorFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var majorId = await this.majorService.Create(
                    model.Name, model.Description, model.MajorType, model.Duration, model.BelongsToDepartment, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = majorId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, MajorFormModel model)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.majorService.Edit(id, model.Name, model.Description, model.MajorType, model.Duration, model.BelongsToDepartment);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            //var faculty = await this.majors.Details(id);

            if (this.majorService == null)
            {
                return this.NotFound();
            }

            return this.View(this.majorService);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            await this.majorService.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
