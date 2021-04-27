namespace UMS.Data.Models.UserDefinedPrincipal
{
    using System;

    using Microsoft.AspNetCore.Identity;

    using Common.Contracts;

    public class ApplicationRole : IdentityRole<int>, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
