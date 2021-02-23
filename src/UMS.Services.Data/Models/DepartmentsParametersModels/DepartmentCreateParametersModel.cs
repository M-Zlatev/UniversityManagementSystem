namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Departments;

    public class DepartmentCreateParametersModel : DepartmentBaseParametersModel, IMapFrom<CreateDepartmentInputForm>
    {
        public string UserId { get; set; }
    }
}
