namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models.Faculties;
    using Data.Repositories.Contracts;
    using Services.Contracts;
    using Services.Data.Models.FacultiesParametersModels;
    using ViewModels;
    using ViewModels.Faculties;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

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
        //[Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateFacultyInputForm();

            return this.View(viewModel);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CreateFacultyInputForm facultyInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = Mapper.Map<FacultyCreateParametersModel>(facultyInputForm);
                var facultyId = await this.facultyService.CreateAsync(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = facultyId });
            }

            return this.View(facultyInputForm);
        }

        [HttpGet]
        //[Authorize]
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
        //[Authorize]
        public async Task<IActionResult> Edit(int id, EditFacultyInputForm facultyInputForm)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = Mapper.Map<FacultyEditParametersModel>(facultyInputForm);
                await this.facultyService.EditAsync(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(facultyInputForm);
        }

        [HttpGet]
        //[Authorize]
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
        //[Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            await this.facultyService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
