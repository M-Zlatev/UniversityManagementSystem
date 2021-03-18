namespace UMS.Services.Data.Models.ResourcesParametersModels
{
    using UMS.Data.Common.Enumerations;

    public class ResourceBaseParametersModel
    {
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }

        public string BelongToCourse { get; set; }

        public string UserId { get; set; }
    }
}
