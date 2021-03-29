namespace UMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.Majors;
    using Data.Repositories.Contracts;
    using Services.Contracts;
    using Services.Data.Models.MajorsParametersModels;
    using ViewModels;
    using ViewModels.Majors;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    public class MajorsController : Controller
    {
        private readonly IDeletableEntityRepository<Major> majorRepository;
        private readonly IMajorsService majorService;

        public MajorsController(IMajorsService majorService, IDeletableEntityRepository<Major> majorRepository)
        {
            this.majorService = majorService;
            this.majorRepository = majorRepository;
        }

        public IActionResult All(int id = 1)
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

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.majorService.GetDetailsById<MajorGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateMajorInputForm();
            viewModel.DepartmentItems = this.majorService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMajorInputForm majorInputForm)
        {
            if (this.ModelState.IsValid)
            {
                majorInputForm.DepartmentItems = this.majorService.GetAllAsKeyValuePairs();
                var parameters = Mapper.Map<MajorCreateParametersModel>(majorInputForm);
                var majorId = await this.majorService.CreateAsync(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = majorId });
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

            var inputModel = this.majorService.GetDetailsById<EditMajorInputForm>(id);
            inputModel.DepartmentItems = this.majorService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
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
                var parameters = Mapper.Map<MajorEditParametersModel>(majorInputForm);
                await this.majorService.EditAsync(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
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

            var major = this.majorRepository.All()
                .Where(m => m.Id == id)
                .FirstOrDefault();

            return this.View(major);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.majorService.Exists(id))
            {
                return this.NotFound();
            }

            await this.majorService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
