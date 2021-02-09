namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Common.Mapping;
    using Services.Contracts;
    using Services.Data.Models.TeachersParametersModels;
    using ViewModels;
    using ViewModels.Teachers;

    public class TeachersController : Controller
    {
        private readonly ITeachersService teachersService;

        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int TeachersPerPage = 10;

            var viewModel = new TeacherGetAllViewModel
            {
                ItemsPerPage = TeachersPerPage,
                PageNumber = id,
                Teachers = this.teachersService.GetAll<TeacherListingViewModel>(id, TeachersPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.teachersService.GetDetails<TeacherDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTeacherInputForm teacherInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<TeacherCreateParametersModel>(teacherInputForm);
                var studentId = await this.teachersService.Create(parameters);

                return this.RedirectToAction(nameof(this.Details), new { id = studentId });
            }

            return this.View(teacherInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditTeacherInputForm teacherInputForm)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<TeacherEditParametersModel>(teacherInputForm);
                await this.teachersService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(teacherInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            await this.teachersService.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
