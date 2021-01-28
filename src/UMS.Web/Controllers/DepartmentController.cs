namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Contracts;

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departments;

        public DepartmentController(IDepartmentService departments)
            => this.departments = departments;

        public async Task<IActionResult> Index()
            => this.Ok(await this.departments.All(1));
    }
}
