namespace UMS.Services.Data.Models.Faculties
{
    using UMS.Data.Models;

    public class FacultyDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressCountryName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
    }
}
