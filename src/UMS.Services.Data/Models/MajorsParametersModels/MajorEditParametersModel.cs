namespace UMS.Services.Data.Models.MajorsParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Majors;

    public class MajorEditParametersModel : MajorBaseParametersModel, IMapFrom<EditMajorInputForm>
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DepartmentItems { get; set; }
    }
}
