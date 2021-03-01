namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "Not specified")]
        NotSpecified = 0,
        Female = 1,
        Male = 2,
        Other = 3,
    }
}
