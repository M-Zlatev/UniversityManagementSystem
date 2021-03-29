namespace UMS.Services.Data.Models.FacultiesParametersModels
{
    using UMS.Data.Common.Enumerations;

    using Additional;

    public abstract class FacultyBaseParametersModel : BaseAddress
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
    }
}
