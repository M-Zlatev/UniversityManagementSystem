namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    public abstract class FacultyBaseParametersModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string StreetName { get; set; }

        public string TownName { get; set; }

        public string CountryName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
    }
}
