namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Models.Department;
    using Services.Data.Contracts;

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departments;

        public DepartmentController(IDepartmentService departments)
            => this.departments = departments;

        public async Task<IActionResult> Index()
            => this.Ok(await this.departments.All(1));

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DepartmentFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var departmentId = await this.departments.Create(
                    model.Name, model.Description, model.Email, model.PhoneNumber, model.Fax, model.BelongsToFaculty, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = departmentId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.departments.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, DepartmentFormModel model)
        {
            if (!await this.departments.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.departments.Edit(id, model.Name, model.Description, model.Email, model.PhoneNumber, model.Fax);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var faculty = await this.departments.Details(id);

            if (this.departments == null)
            {
                return this.NotFound();
            }

            return this.View(this.departments);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.departments.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.departments.Exists(id))
            {
                return this.NotFound();
            }

            await this.departments.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
