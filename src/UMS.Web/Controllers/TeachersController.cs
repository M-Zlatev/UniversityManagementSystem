namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Services.Contracts;
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
        public async Task<IActionResult> Create(TeacherFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = await this.teachersService.Create(model.FirstName, model.MiddleName, model.LastName, model.Gender, model.AddressStreetName, model.AddressTownName, model.AddressDistrictName, model.AddressCountryName, model.AddressContinentName, model.PhoneNumber, model.Email, model.ImageUrl, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = studentId });
            }

            return this.View(model);
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
        public async Task<IActionResult> Edit(int id, TeacherFormModel model)
        {
            if (!await this.teachersService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.teachersService.Edit(id, model.FirstName, model.MiddleName, model.LastName, model.Gender, model.AddressStreetName, model.AddressTownName, model.AddressDistrictName, model.AddressCountryName, model.AddressContinentName, model.PhoneNumber, model.Email, model.ImageUrl);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
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
