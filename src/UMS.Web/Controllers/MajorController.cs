namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Contracts;

    public class MajorController : Controller
    {
        private readonly IMajorService majors;

        public MajorController(IMajorService majors)
            => this.majors = majors;

        public async Task<IActionResult> Index()
            => this.Ok(await this.majors.All(1));
    }
}
