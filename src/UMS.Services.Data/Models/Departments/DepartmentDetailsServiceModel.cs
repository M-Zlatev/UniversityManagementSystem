namespace UMS.Services.Data.Models.Departments
{
    public class DepartmentDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string BelongsToFaculty { get; set; }
    }
}
