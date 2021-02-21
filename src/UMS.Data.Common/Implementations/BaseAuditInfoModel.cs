namespace UMS.Data.Common.Contracts
{
    using System;

    using System.ComponentModel.DataAnnotations;

    public abstract class BaseAuditInfoModel : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
