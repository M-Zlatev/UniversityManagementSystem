namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Departments;

    public class DepartmentEditParametersModel : DepartmentBaseParametersModel, IMapFrom<EditDepartmentInputForm>
    {
        public string Id { get; set; }
    }
}
