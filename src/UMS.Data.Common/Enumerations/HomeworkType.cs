namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum HomeworkType
    {
        Assignment = 0,
        Essay = 1,
        Composition = 2,
        Presentation = 3,
        Test = 4,
        [Display(Name = "Filling the gap")]
        FillingTheGap = 5,
        [Display(Name = "Solving problems")]
        SolvingProblems = 6,
        [Display(Name = "Group project")]
        GroupProject = 7,
    }
}
