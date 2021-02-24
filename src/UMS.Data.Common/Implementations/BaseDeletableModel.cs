namespace UMS.Data.Common.Implementations
{
    using System;

    using Contracts;

    public abstract class BaseDeletableModel : BaseAuditInfoModel, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
