namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Data.Common.Enumerations;
    using Infrastructure;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Resources;

    public class ResourcesController : Controller
    {
        private readonly IResourcesService resourcesService;

        public ResourcesController(IResourcesService resourceService)
            => this.resourcesService = resourceService;

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
        public IActionResult Create(int id)
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateResourceInputForm inputForm)
        {
            if (this.ModelState.IsValid)
            {
                var courseId = await this.resourcesService.Create(inputForm.Name, inputForm.ResourceType, inputForm.Url, inputForm.BelongToCourse);

                return this.RedirectToAction(nameof(this.ById), new { id = courseId });
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

            return this.View();
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
                await this.resourcesService.Edit(id, inputForm.Name, inputForm.ResourceType, inputForm.Url, inputForm.BelongToCourse);

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

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.resourcesService.Exists(id))
            {
                return this.NotFound();
            }

            await this.resourcesService.Delete(id);

            return this.Redirect(nameof(this.All));
        }
    }
}
