namespace UMS.Services.Models.Departments
{
    public class DepartmentListingServiceModel
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public string BelongsToFaculty { get; set; }
    }
}
