namespace UMS.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Models.Faculty;
    using Services.Data.Contracts;

    public class FacultyController : Controller
    {
        private readonly IFacultyService faculties;

        public FacultyController(IFacultyService faculties)
            => this.faculties = faculties;

        public async Task<IActionResult> Index(int page = 1)
            => this.Ok(await this.faculties.All(page));

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(FacultyFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var facultyId = await this.faculties.Create(
                    model.Name, model.Description, model.AddressStreetName, model.AddressTownName, model.AddressCountryName, model.Email, model.PhoneNumber, model.Fax, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = facultyId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.faculties.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, FacultyFormModel model)
        {
            if (!await this.faculties.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.faculties.Edit(id, model.Name, model.Description, model.AddressStreetName, model.AddressTownName, model.AddressCountryName, model.Email, model.PhoneNumber, model.Fax);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var faculty = await this.faculties.Details(id);

            if (this.faculties == null)
            {
                return this.NotFound();
            }

            return this.View(this.faculties);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.faculties.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.faculties.Exists(id))
            {
                return this.NotFound();
            }

            await this.faculties.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
