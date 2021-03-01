namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum AcademicDegree
    {
        [Display(Name = "Undergraduate degree")]
        Undergraduate = 0,
        [Display(Name = "Bachelor's degree")]
        Bachelor = 1,
        [Display(Name = "Master's degree")]
        Master = 2,
        Doctorate = 3,
        [Display(Name = "Doctor of Philosophy")]
        PhD = 4,
        [Display(Name = "Honorary doctorate")]
        HonoraryDoctorate = 5,
    }
}
