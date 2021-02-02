﻿namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Models.Department;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Departments;

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departments)
            => this.departmentService = departments;

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int DepartmentsPerPage = 10;

            var viewModel = new DepartmentGetAllViewModel
            {
                ItemsPerPage = DepartmentsPerPage,
                PageNumber = id,
                GetAllDepartmentViewModel = this.departmentService.GetAll<DepartmentListingViewModel>(id, DepartmentsPerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DepartmentFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var departmentId = await this.departmentService.Create(
                    model.Name, model.Description, model.Email, model.PhoneNumber, model.Fax, model.BelongsToFaculty, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = departmentId });
            }

            return this.View(model);
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
        public async Task<IActionResult> Edit(int id, DepartmentFormModel model)
        {
            if (!await this.departmentService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.departmentService.Edit(id, model.Name, model.Description, model.Email, model.PhoneNumber, model.Fax);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            //var faculty = await this.departmentService.Details(id);

            if (this.departmentService == null)
            {
                return this.NotFound();
            }

            return this.View(this.departmentService);
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

            return this.Redirect(nameof(this.Index));
        }
    }
}
