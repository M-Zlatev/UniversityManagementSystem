namespace UMS.Services.Data.Models.MajorsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Majors;

    public class MajorEditParametersModel : MajorBaseParametersModel, IMapFrom<EditMajorInputForm>
    {
        public int Id { get; set; }
    }
}
