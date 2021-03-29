namespace UMS.Web.ViewModels.Majors
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data.Models.Majors;
    using Services.Mapping.Contracts;

    public class EditMajorInputForm : MajorBaseForm, IMapFrom<Major>
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DepartmentItems { get; set; }
    }
}
