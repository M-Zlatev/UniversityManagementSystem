namespace UMS.Web.ViewModels.Departments
{
    using Common.Mapping;
    using Data.Models;

    public class EditDepartmentInputForm : DepartmentBaseForm, IMapFrom<Department>
    {
        public int Id { get; set; }
    }
}
