namespace UMS.Services.Data.Models.MajorsParametersModels
{
    using Common.Mapping;
    using Web.ViewModels.Majors;

    public class MajorCreateParametersModel : MajorBaseParametersModel, IMapFrom<CreateMajorInputForm>
    {
        public string UserId { get; set; }
    }
}
