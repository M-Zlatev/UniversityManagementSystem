namespace UMS.Data.Common.Models
{
    using System;

    public abstract class BaseDeletableModel : BaseAuditInfoModel, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string DeletedBy { get; set; }
    }
}
