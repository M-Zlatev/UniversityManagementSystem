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
    using Services.Contracts;
    using Services.Data.Models.TeachersParametersModels;
    using ViewModels;
    using ViewModels.Teachers;

    public class TeachersController : Controller
    {
        private readonly IDeletableEntityRepository<Teacher> teacherRepository;
        private readonly ITeachersService teachersService;

        public TeachersController(ITeachersService teachersService, IDeletableEntityRepository<Teacher> teacherRepository)
        {
            this.teachersService = teachersService;
            this.teacherRepository = teacherRepository;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int TeachersPerPage = 10;

            var viewModel = new TeacherGetAllViewModel
            {
                ItemsPerPage = TeachersPerPage,
                Count = this.teachersService.GetCount(),
                PageNumber = id,
                Teachers = this.teachersService.GetAll<TeacherListingViewModel>(id, TeachersPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.teachersService.GetDetailsById<TeacherGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateTeacherInputForm();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTeacherInputForm teacherInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<TeacherCreateParametersModel>(teacherInputForm);
                var teacherId = await this.teachersService.Create(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = teacherId });
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

            var inputModel = this.teachersService.GetDetailsById<EditTeacherInputForm>(id);
            return this.View(inputModel);
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

                return this.RedirectToAction(nameof(this.ById), new { id });
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

            var teacher = this.teacherRepository.All()
                .Where(d => d.Id == id)
                .FirstOrDefault();

            return this.View(teacher);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            await this.teachersService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
