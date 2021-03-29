namespace UMS.Services.Data.Models.MajorsParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Majors;

    public class MajorCreateParametersModel : MajorBaseParametersModel, IMapFrom<CreateMajorInputForm>
    {
        public string UserId { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DepartmentItems { get; set; }
    }
}
