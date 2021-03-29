namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Departments;

    public class DepartmentCreateParametersModel : DepartmentBaseParametersModel, IMapFrom<CreateDepartmentInputForm>
    {
        public string UserId { get; set; }

        public int FacultyId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FacultyItems { get; set; }
    }
}
