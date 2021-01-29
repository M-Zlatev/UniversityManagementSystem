namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Models.Major;
    using Services.Data.Contracts;

    public class MajorController : Controller
    {
        private readonly IMajorService majors;

        public MajorController(IMajorService majors)
            => this.majors = majors;

        public async Task<IActionResult> Index()
            => this.Ok(await this.majors.All(1));

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(MajorFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var majorId = await this.majors.Create(
                    model.Name, model.Description, model.MajorType, model.Duration, model.BelongsToDepartment, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = majorId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.majors.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, MajorFormModel model)
        {
            if (!await this.majors.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.majors.Edit(id, model.Name, model.Description, model.MajorType, model.Duration, model.BelongsToDepartment);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var faculty = await this.majors.Details(id);

            if (this.majors == null)
            {
                return this.NotFound();
            }

            return this.View(this.majors);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.majors.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.majors.Exists(id))
            {
                return this.NotFound();
            }

            await this.majors.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
