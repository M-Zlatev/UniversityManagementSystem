namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    public abstract class DepartmentBaseParametersModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
    }
}
