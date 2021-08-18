namespace UMS.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;

    using UMS.Services.Contracts;

    public class UniversityDivisionsCountViewComponent : ViewComponent
    {
        private readonly IUniversityDivisionsCountService universityDivisions;

        public UniversityDivisionsCountViewComponent(IUniversityDivisionsCountService universityDivisions)
        {
            this.universityDivisions = universityDivisions;
        }

        public IViewComponentResult Invoke()
        {
            var result = this.universityDivisions.GetUniversityDivisionsCount();
            return this.View(result);
        }
    }
}
