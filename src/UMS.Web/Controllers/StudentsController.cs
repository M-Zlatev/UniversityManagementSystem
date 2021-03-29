namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.Students;
    using Data.Repositories.Contracts;
    using Services.Contracts;
    using Services.Data.Models.StudentsParametersModels;
    using ViewModels.Students;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    public class StudentsController : Controller
    {
        private readonly IDeletableEntityRepository<Student> studentRepository;
        private readonly IStudentsService studentService;

        public StudentsController(IStudentsService studentService, IDeletableEntityRepository<Student> studentRepository)
        {
            this.studentService = studentService;
            this.studentRepository = studentRepository;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int StudentsPerPage = 10;

            var viewModel = new StudentGetAllViewModel
            {
                ItemsPerPage = StudentsPerPage,
                Count = this.studentService.GetCount(),
                PageNumber = id,
                Students = this.studentService.GetAll<StudentListingViewModel>(id, StudentsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.studentService.GetDetailsById<StudentGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateStudentInputForm();
            viewModel.MajorItems = this.studentService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateStudentInputForm studentInputForm)
        {
            if (this.ModelState.IsValid)
            {
                studentInputForm.MajorItems = this.studentService.GetAllAsKeyValuePairs();
                var parameters = Mapper.Map<StudentCreateParametersModel>(studentInputForm);
                var studentId = await this.studentService.CreateAsync(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = studentId });
            }

            return this.View(studentInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.studentService.GetDetailsById<EditStudentInputForm>(id);
            inputModel.MajorItems = this.studentService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditStudentInputForm studentInputForm)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = Mapper.Map<StudentEditParametersModel>(studentInputForm);
                await this.studentService.EditAsync(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(studentInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            var student = this.studentRepository.All()
                .Where(d => d.Id == id)
                .FirstOrDefault();

            return this.View(student);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            await this.studentService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
