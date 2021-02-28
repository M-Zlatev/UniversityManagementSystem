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
    using Services.Data.Models.DepartmentsParametersModels;
    using ViewModels;
    using ViewModels.Departments;

    public class DepartmentsController : Controller
    {
        private readonly IDeletableEntityRepository<Department> departmentRepository;
        private readonly IDepartmentsService departmentService;

        public DepartmentsController(IDepartmentsService departments, IDeletableEntityRepository<Department> departmentRepository)
        {
            this.departmentService = departments;
            this.departmentRepository = departmentRepository;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int DepartmentsPerPage = 10;

            var viewModel = new DepartmentGetAllViewModel
            {
                ItemsPerPage = DepartmentsPerPage,
                Count = this.departmentService.GetCount(),
                PageNumber = id,
                Departments = this.departmentService.GetAll<DepartmentListingViewModel>(id, DepartmentsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.departmentService.GetDetailsById<DepartmentGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateDepartmentInputForm();
            viewModel.FacultyItems = this.departmentService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CreateDepartmentInputForm departmentFormInput)
        {
            if (this.ModelState.IsValid)
            {
                departmentFormInput.FacultyItems = this.departmentService.GetAllAsKeyValuePairs();
                var parameters = AutoMapperConfig.MapperInstance.Map<DepartmentCreateParametersModel>(departmentFormInput);
                var departmentId = await this.departmentService.Create(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = departmentId });
            }

            return this.View(departmentFormInput);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.departmentService.GetDetailsById<EditDepartmentInputForm>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Edit(int id, EditDepartmentInputForm departmentFormInput)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<DepartmentEditParametersModel>(departmentFormInput);
                await this.departmentService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(departmentFormInput);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            var department = this.departmentRepository.All()
                .Where(d => d.Id == id)
                .FirstOrDefault();

            return this.View(department);
        }

        [HttpPost]
        //[Authorize]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            await this.departmentService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
