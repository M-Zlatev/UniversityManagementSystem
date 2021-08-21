namespace UMS.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;

    using UMS.Services.Contracts;

    public class UniversityDivisionsCountViewComponent : ViewComponent
    {
        private readonly IGetCountsService getCountsService;

        public UniversityDivisionsCountViewComponent(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IViewComponentResult Invoke()
        {
            var result = this.getCountsService.GetUniversityDivisionsCount();
            return this.View(result);
        }
    }
}
