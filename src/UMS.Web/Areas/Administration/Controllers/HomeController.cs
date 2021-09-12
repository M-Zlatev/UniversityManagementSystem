namespace UMS.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using ViewModels.Administration;

    [Area("Administration")]
    public class HomeController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public HomeController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
