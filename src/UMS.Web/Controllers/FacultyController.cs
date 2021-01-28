namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Contracts;

    public class FacultyController : Controller
    {
        private readonly IFacultyService faculties;

        public FacultyController(IFacultyService faculties)
            => this.faculties = faculties;

        public async Task<IActionResult> Index()
            => this.Ok(await this.faculties.All(1));
    }
}
