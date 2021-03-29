namespace UMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using Data.Models.Resources;
    using Data.Repositories.Contracts;
    using Services.Contracts;
    using Services.Data.Models.ResourcesParametersModels;
    using ViewModels.Resources;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    public class ResourcesController : Controller
    {
        private readonly IRepository<Resource> resourceRepository;
        private readonly IResourcesService resourcesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ResourcesController(
            IResourcesService resourceService,
            IRepository<Resource> resourceRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.resourcesService = resourceService;
            this.resourceRepository = resourceRepository;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ResourcesPerPage = 10;

            var viewModel = new ResourceGetAllViewModel
            {
                ItemsPerPage = ResourcesPerPage,
                Count = this.resourcesService.GetCount(),
                PageNumber = id,
                Resources = this.resourcesService.GetAll<ResourceListingViewModel>(id, ResourcesPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.resourcesService.GetDetailsById<ResourceGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int id)
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateResourceInputForm inputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = Mapper.Map<ResourceCreateParametersModel>(inputForm);
                var user = await this.userManager.GetUserAsync(this.User);
                parameters.UserId = user.Id;
                var resourceId = await this.resourcesService.CreateAsync(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = resourceId });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.resourcesService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.resourcesService.GetDetailsById<EditResourceInputForm>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditResourceInputForm inputForm)
        {
            if (!await this.resourcesService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = Mapper.Map<ResourceEditParametersModel>(inputForm);
                var user = await this.userManager.GetUserAsync(this.User);
                parameters.UserId = user.Id;
                await this.resourcesService.EditAsync(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(inputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.resourcesService.Exists(id))
            {
                return this.NotFound();
            }

            var resource = this.resourceRepository.All()
                 .Where(d => d.Id == id)
                 .FirstOrDefault();

            return this.View(resource);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.resourcesService.Exists(id))
            {
                return this.NotFound();
            }

            await this.resourcesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
