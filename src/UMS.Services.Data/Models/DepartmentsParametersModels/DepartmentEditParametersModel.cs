﻿namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Departments;

    public class DepartmentEditParametersModel : DepartmentBaseParametersModel, IMapFrom<EditDepartmentInputForm>
    {
        public string Id { get; set; }
    }
}
