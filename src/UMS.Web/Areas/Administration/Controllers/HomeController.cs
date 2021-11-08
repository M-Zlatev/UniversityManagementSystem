namespace UMS.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GlobalConstants;

    [Authorize(Roles = AdministratorRoleName)]
    [Area("Administration")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("Index", "Administrator");
        }
    }
}
