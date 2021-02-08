namespace UMS.Services.Data.Models.DepartmentsParametersModels
{
    public class DepartmentCreateParametersModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string BelongsToFaculty { get; set; }

        public string UserId { get; set; }
    }
}
