namespace UMS.Services.Data.Models.Departments
{
    public class DepartmentListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BelongsToFaculty { get; set; }
    }
}
