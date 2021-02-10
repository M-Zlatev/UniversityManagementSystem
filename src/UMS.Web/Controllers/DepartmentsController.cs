namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Infrastructure;
    using Services.Contracts;
    using Services.Data.Models.DepartmentsParametersModels;
    using ViewModels;
    using ViewModels.Departments;

    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsService departmentService;

        public DepartmentsController(IDepartmentsService departments)
            => this.departmentService = departments;

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
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateDepartmentInputForm departmentFormInput)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<DepartmentCreateParametersModel>(departmentFormInput);
                var departmentId = await this.departmentService.Create(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = departmentId });
            }

            return this.View(departmentFormInput);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            await this.departmentService.Delete(id);

            return this.Redirect(nameof(this.All));
        }
    }
}
