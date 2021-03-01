namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum MajorType
    {
        [Display(Name = "Not specified")]
        NotSpecified = 0,
        [Display(Name = "Bachelor's degree")]
        BachelorsDegree = 1,
        [Display(Name = "Master's degree")]
        MastersDegree = 2,
        Doctorate = 3,
    }
}
