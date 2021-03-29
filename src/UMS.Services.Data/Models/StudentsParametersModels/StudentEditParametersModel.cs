﻿namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using System.Collections.Generic;

    using UMS.Services.Mapping.Contracts;
    using Web.ViewModels.Students;

    public class StudentEditParametersModel : StudentBaseParametersModel, IMapFrom<EditStudentInputForm>
    {
        public int Id { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MajorItems { get; set; }
    }
}
