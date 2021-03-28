namespace UMS.Web.ViewModels.Resources
{
    using Common.Mapping;
    using Data.Models.Resources;

    public class EditResourceInputForm : ResourceBaseForm, IMapFrom<Resource>
    {
        public int Id { get; set; }
    }
}
