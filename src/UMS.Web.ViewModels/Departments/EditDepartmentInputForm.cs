namespace UMS.Web.ViewModels.Departments
{
    using Data.Models.Departments;
    using Services.Mapping.Contracts;

    public class EditDepartmentInputForm : DepartmentBaseForm, IMapFrom<Department>
    {
        public int Id { get; set; }
    }
}
