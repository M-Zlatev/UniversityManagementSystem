namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum ResourceType
    {
        [Display(Name = "Web link")]
        WebLink = 0,
        Presentation = 1,
        Document = 2,
        Video = 3,
        Other = 4,
    }
}
