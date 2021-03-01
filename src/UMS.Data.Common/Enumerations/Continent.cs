namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum Continent
    {
        // The enum values here are listed in ascending/alphabetical order.
        [Display(Name = "Not specified")]
        NotSpecified = 0,
        Africa = 1,
        Antarctica = 2,
        Asia = 3,
        Australia = 4,
        Europe = 5,
        [Display(Name = "North America")]
        NorthAmerica = 6,
        [Display(Name = "South America")]
        SouthAmerica = 7,
    }
}
