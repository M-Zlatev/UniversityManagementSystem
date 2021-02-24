namespace UMS.Data.Common.Implementations
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public abstract class BaseAuditInfoModel : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
