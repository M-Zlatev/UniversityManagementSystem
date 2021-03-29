namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Students;

    public class StudentCreateParametersModel : StudentBaseParametersModel, IMapFrom<CreateStudentInputForm>
    {
        public int UserId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
