namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Infrastructure;
    using Services.Contracts;
    using Services.Data.Models.MajorsParametersModels;
    using Services.Implementations;
    using ViewModels;
    using ViewModels.Majors;

    public class MajorsController : Controller
    {
        private readonly IMajorsService majorService;

        public MajorsController(IMajorsService majors)
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
                Count = this.majorService.GetCount(),
                PageNumber = id,
                Majors = this.majorService.GetAll<MajorListingViewModel>(id, MajorsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.majorService.GetDetails<MajorDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMajorInputForm majorInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<MajorCreateParametersModel>(majorInputForm);
                var majorId = await this.majorService.Create(parameters);

                return this.RedirectToAction(nameof(this.Details), new { id = majorId });
            }

            return this.View(majorInputForm);
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
        public async Task<IActionResult> Edit(int id, EditMajorInputForm majorInputForm)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<MajorEditParametersModel>(majorInputForm);
                await this.majorService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(majorInputForm);
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
