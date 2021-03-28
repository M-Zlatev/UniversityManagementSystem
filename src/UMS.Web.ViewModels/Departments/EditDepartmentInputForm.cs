namespace UMS.Web.ViewModels.Departments
{
    using Common.Mapping;
    using Data.Models.Departments;

    public class EditDepartmentInputForm : DepartmentBaseForm, IMapFrom<Department>
    {
        public int Id { get; set; }
    }
}
