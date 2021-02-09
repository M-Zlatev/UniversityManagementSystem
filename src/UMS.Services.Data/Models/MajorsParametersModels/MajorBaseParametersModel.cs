namespace UMS.Services.Data.Models.MajorsParametersModels
{
    using UMS.Data.Common.Enumerations;

    public abstract class MajorBaseParametersModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MajorType MajorType { get; set; }

        public double Duration { get; set; }

        public string BelongsToDepartment { get; set; }
    }
}
