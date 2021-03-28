namespace UMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Data.Models;
    using Data.Models.Faculties;
    using Data.Repositories.Contracts;
    using Infrastructure;
    using Services.Contracts;
    using Services.Data.Models.FacultiesParametersModels;
    using ViewModels;
    using ViewModels.Faculties;

    public class FacultiesController : Controller
    {
        private readonly IDeletableEntityRepository<Faculty> facultyRepository;
        private readonly IFacultiesService facultyService;

        public FacultiesController(IFacultiesService faculties, IDeletableEntityRepository<Faculty> facultyRepository)
        {
            this.facultyRepository = facultyRepository;
            this.facultyService = faculties;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int FacultyPerPage = 10;

            var viewModel = new FacultyGetAllViewModel
            {
                ItemsPerPage = FacultyPerPage,
                Count = this.facultyService.GetCount(),
                PageNumber = id,
                Faculties = this.facultyService.GetAll<FacultyListingViewModel>(id, FacultyPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.facultyService.GetDetailsById<FacultyGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateFacultyInputForm();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateFacultyInputForm facultyInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<FacultyCreateParametersModel>(facultyInputForm);
                var facultyId = await this.facultyService.Create(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = facultyId });
            }

            return this.View(facultyInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.facultyService.GetDetailsById<EditFacultyInputForm>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditFacultyInputForm facultyInputForm)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<FacultyEditParametersModel>(facultyInputForm);
                await this.facultyService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(facultyInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            var faculty = this.facultyRepository.All().Where(f => f.Id == id).FirstOrDefault();
            return this.View(faculty);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            await this.facultyService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
