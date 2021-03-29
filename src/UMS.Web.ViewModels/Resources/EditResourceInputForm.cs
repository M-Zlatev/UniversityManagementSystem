namespace UMS.Web.ViewModels.Resources
{
    using Data.Models.Resources;
    using Services.Mapping.Contracts;

    public class EditResourceInputForm : ResourceBaseForm, IMapFrom<Resource>
    {
        public int Id { get; set; }
    }
}
