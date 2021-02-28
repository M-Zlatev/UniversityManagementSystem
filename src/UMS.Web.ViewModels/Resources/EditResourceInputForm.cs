namespace UMS.Web.ViewModels.Resources
{
    using Common.Mapping;
    using Data.Models;

    public class EditResourceInputForm : ResourceBaseForm, IMapFrom<Resource>
    {
        public int Id { get; set; }
    }
}
