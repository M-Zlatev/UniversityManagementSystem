namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using UMS.Data.Common.Enumerations;

    public abstract class TeacherBaseParametersModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        public string ImageUrl { get; set; }
    }
}
